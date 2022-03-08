using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entity;

namespace WebApiUnitTests.TestSetup
{
   public static class MovieActors
    {
        public static void AddMovieActors(this MovieStoreDbContext context)
        {
            context.MovieActors.Add(new MovieActor { ActorId = 1, MovieId = 1 });
            context.MovieActors.Add(new MovieActor { ActorId = 2, MovieId = 1 });
            context.MovieActors.Add(new MovieActor { ActorId = 3, MovieId = 1 });
            context.MovieActors.Add(new MovieActor { ActorId = 5, MovieId = 2 });
            context.MovieActors.Add(new MovieActor { ActorId = 2, MovieId = 2 });
            context.MovieActors.Add(new MovieActor { ActorId = 1, MovieId = 3 });
            context.MovieActors.Add(new MovieActor { ActorId = 3, MovieId = 3 });

            context.SaveChanges();
        }
    }
}
