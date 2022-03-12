using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entity;

namespace WebApi.Application.ActorOperations.Command
{
    public class ActorUpdateCommand
    {
        private readonly IMovieStoreDbContext _context;
        public ActorUpdateModel Model { get; set; }
        public int ModelId { get; set; }

        public ActorUpdateCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var actor = _context.Actors.SingleOrDefault(p => p.Id == ModelId);


            //if (actor is not null)
            //{
            //    throw new InvalidOperationException("Oyuncu zaten kayıtlı.");
            //}



            actor.Name = Model.Name;
            actor.Surname = Model.Surname;
            actor.MovieActors = new List<MovieActor>();


            if (Model.PlayedMovieIds is not null)
            {
                List<MovieActor> movieActorList = new();
                foreach (var id in Model.PlayedMovieIds)
                {
                    var playedMovie = _context.Movies.SingleOrDefault(p => p.Id == id);
                    if (playedMovie is not null)
                    {
                        actor.MovieActors.Add(new MovieActor { Movie = playedMovie, Actors = actor });
                    }
                    else if (playedMovie is null)
                    {
                        throw new InvalidOperationException("Flim bulunamadı.");
                    }
                }
            }

            _context.Actors.Update(actor);
            _context.SaveChanges();
        }

        public class ActorUpdateModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }

            public ICollection<int> PlayedMovieIds { get; set; }
        }
    }
}
