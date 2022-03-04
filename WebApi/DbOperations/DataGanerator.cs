using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entity;

namespace WebApi.DbOperations
{
    public class DataGanerator
    {
        public static void Initializer(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {
                if (context.Movies.Any())
                {
                    return;
                }
                context.Movies.AddRange(
                    new Entity.Movie
                    {
                        MovieName = "Yüzüklerin Efendisi Yüzük Kardeşliği",
                        DirectorId = 1,
                        Price = 30,
                        TypeId = 1,
                        Year = 2001,
                    },
                     new Entity.Movie
                     {
                         MovieName = "Yüzüklerin Efendisi Yüzük Kardeşliği",
                         DirectorId = 1,
                         Price = 30,
                         TypeId = 1,
                         Year = 2001,
                     },
                      new Entity.Movie
                      {
                          MovieName = "Yüzüklerin Efendisi Yüzük Kardeşliği",
                          DirectorId = 1,
                          Price = 30,
                          TypeId = 1,
                          Year = 2001,
                      });

                context.MovieTypes.AddRange(
                    new MovieType
                    {
                        Type = "Aksyion"
                    },
                    new MovieType
                    {
                        Type = "Macera"
                    },
                    new MovieType
                    {
                        Type = "Belgesel"
                    });

                context.Directors.AddRange(new Director
                {
                    Name = "Peter",
                    Surname = "Jackson"
                });

                context.Actors.AddRange
                    (
                    new Actor { Name = "Elijah", Surname = "Wood" },
                    new Actor { Name = "Viggo", Surname = "Mortensen" },
                    new Actor { Name = "Sean", Surname = "Astin" },
                    new Actor { Name = "Orlando", Surname = "Bloom" },
                    new Actor { Name = "Ian", Surname = "McKellen" }
                    );

                //context.MovieActors.AddRange(
                //     new MovieActor { ActorId = 1, MovieId = 1 },
                //     new MovieActor { ActorId = 2, MovieId = 1 },
                //     new MovieActor { ActorId = 3, MovieId = 2 },
                //     new MovieActor { ActorId = 4, MovieId = 2 },
                //     new MovieActor { ActorId = 3, MovieId = 2 });

                context.MovieActors.Add(new MovieActor { ActorId= 1,MovieId= 1 });
                context.MovieActors.Add(new MovieActor { ActorId= 2,MovieId= 1 });
                context.MovieActors.Add(new MovieActor { ActorId= 3,MovieId= 1 });
                

                context.SaveChanges();
            }
        }
    }
}
