using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entity;


namespace WebApi.Application.ActorOperations.Query.GetAll
{
    public class ActorGetAllQuery
    {
        private readonly IMovieStoreDbContext _context;

        public ActorGetAllQuery(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ActorModel> Handle()
        {
            List<ActorModel> actorList = new();

            var actors = _context.Actors.
                Include(x => x.MovieActors)
                .ThenInclude(x => x.Movie)
                .OrderBy(p => p.Id);

            foreach (var actor in actors)
            {
                actorList.Add(new ActorModel
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
                });
            }

            return actorList;

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
}
