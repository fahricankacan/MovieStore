using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entity;

namespace WebApi.Application.ActorOperations.Command
{
    public class ActorCreateCommand
    {
        IMovieStoreDbContext _movieStoreDbContext;
        public ActorCreateModel Model { get; set; }



        public ActorCreateCommand(IMovieStoreDbContext movieStoreDbContext)
        {
            _movieStoreDbContext = movieStoreDbContext;
            
        }

        public void Handle()
        {
            var actor = _movieStoreDbContext.Actors.SingleOrDefault(p => p.Name + " " + p.Surname == Model.Name + " " + Model.Surname);
        

            if (actor is not null)
            {
                throw new InvalidOperationException("Oyuncu zaten kayıtlı.");
            }


            actor = new Entity.Actor()
            {
                Name = Model.Name,
                Surname = Model.Surname,
                MovieActors = new List<MovieActor>()

            };

            if (Model.PlayedMovieIds is not null)
            {
                List<MovieActor> movieActorList = new();
                foreach (var id in Model.PlayedMovieIds)
                {
                    var playedMovie = _movieStoreDbContext.Movies.SingleOrDefault(p => p.Id == id);
                    if(playedMovie is not null)
                    {
                        actor.MovieActors.Add(new MovieActor { Movie = playedMovie, Actors = actor });
                    }
                    else if(playedMovie is null)
                    {
                        throw new InvalidOperationException("Flim bulunamadı.");
                    }
                }
            }

            _movieStoreDbContext.Actors.Add(actor);
            _movieStoreDbContext.SaveChanges();
           
         
        }


        public class ActorCreateModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }

            public List<int> PlayedMovieIds { get; set; }
        }
    }
}
