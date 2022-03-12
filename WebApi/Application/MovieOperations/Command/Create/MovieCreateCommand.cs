using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entity;

namespace WebApi.Application.MovieOperations.Command.Create
{
    public class MovieCreateCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public MovieCreateModel CreateModel { get; set; }

        public MovieCreateCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {

            var movie = _context.Movies.SingleOrDefault(p => p.MovieName == CreateModel.MovieName);

            if(movie is not null)
            {
                throw new InvalidOperationException("Flim daha önce eklenmiş.");
            }

            movie = new Movie
            {
                DirectorId = CreateModel.DirectorId,
                IsActive = true,
                MovieName = CreateModel.MovieName,
                MovieTypeId = CreateModel.MovieTypeId,
                Price = CreateModel.Price,
                Year = CreateModel.Year,
                MovieActors = new List<MovieActor>()
            };

            

            // var movie = _mapper.Map<Movie>(CreateModel);

            foreach (var actorId in CreateModel.MovieActorsId)
            {
                var actorResult = _context.Actors.SingleOrDefault(p => p.Id == actorId);
                var directorResult = _context.Directors.SingleOrDefault(p => p.Id == CreateModel.DirectorId);

                if (actorResult is not null && directorResult is not null)
                {
                    movie.MovieActors.Add(new MovieActor { Actors = actorResult, Movie = movie });
                }
                else if (actorResult is null)
                {
                    throw new InvalidOperationException("Aktör bulunamadı.");
                }
                else if (directorResult is null)
                {
                    throw new InvalidOperationException("Yönetmen bulunamadı.");
                }
            }
            _context.Movies.Add(movie);
            _context.SaveChanges();

        }
        

        public class MovieCreateModel
        {
            public string MovieName { get; set; }
            public decimal Price { get; set; }
            public int Year { get; set; }

            public int MovieTypeId { get; set; }

            public int DirectorId { get; set; }

            public ICollection<int> MovieActorsId { get; set; }

        }
    }
}
//https://stackoverflow.com/questions/38893873/saving-many-to-many-relationship-in-entity-framework-core