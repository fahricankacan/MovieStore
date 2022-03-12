using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Application.ActorOperations.Query.GetById
{
    public class ActorGetByIdQuery
    {
        private readonly IMovieStoreDbContext _context;
        public int ModelId { get; set; }

        public ActorGetByIdQuery(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public ActorModel Handle()
        {
            List<ActorModel> actorList = new();

            var actor = _context.Actors.
                Include(x => x.MovieActors)                
                .ThenInclude(x => x.Movie)
                .SingleOrDefault(p => p.Id == ModelId);

            if(actor is null)
            {
                throw new InvalidOperationException("Aktör bulunamadı.");
            }

            return new ActorModel
            {
                Id = actor.Id,
                Name = actor.Name,
                Surname = actor.Surname,
                PlayedMovies = actor.MovieActors
                .Select(p =>
                new PlayedMovieInfo
                {
                    MovieName = p.Movie.MovieName,
                    Price = p.Movie.Price,
                    Year = p.Movie.Year
                }).ToList()
            };
        }
    }

    public class ActorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public IEnumerable<PlayedMovieInfo> PlayedMovies;
    }

    public class PlayedMovieInfo
    {
        public string MovieName { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
    }
}

