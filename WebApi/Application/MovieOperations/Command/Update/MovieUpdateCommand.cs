using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entity;

namespace WebApi.Application.MovieOperations.Command.Update
{
    public class MovieUpdateCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public MovieUpdateModel UpdateModel { get; set; }
        public int ModelId { get; set; }

        public MovieUpdateCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var movie = _context.Movies.Include(x => x.MovieActors).ThenInclude(a => a.Actors).SingleOrDefault(p => p.Id == ModelId);
            var actorIds = UpdateModel.MovieActorsId.ToList();

            List<MovieActor> movieActorList = new();

            if (movie is null)
            {
                throw new InvalidOperationException("Flim bulunamadı.");
            }

            movie.MovieName = UpdateModel.MovieName == default ? movie.MovieName : UpdateModel.MovieName;
            movie.Price = UpdateModel.Price == default ? movie.Price : UpdateModel.Price;
            movie.Year = UpdateModel.Year == default ? movie.Year : UpdateModel.Year;
            movie.MovieTypeId = UpdateModel.MovieTypeId == default ? movie.MovieTypeId : UpdateModel.MovieTypeId;
            movie.DirectorId = UpdateModel.DirectorId == default ? movie.DirectorId : UpdateModel.DirectorId;


            if (actorIds is not null)
            {        
                foreach (var id in actorIds)
                {
                    movieActorList.Add(new MovieActor
                    {
                        MovieId=ModelId,
                        ActorId=id,                      
                    });
                }
                movie.MovieActors = movieActorList;
            }
            _context.Movies.Update(movie);
            _context.SaveChanges();
        }


        public class MovieUpdateModel
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
