using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entity;

namespace WebApiUnitTests.TestSetup
{
    public static partial class Movies
    {
        public static void AddMovies(this MovieStoreDbContext context)
        {
            context.Movies.AddRange(
                 new Movie
                 {
                     MovieName = "Yüzüklerin Efendisi Yüzük Kardeşliği",
                     DirectorId = 1,
                     Price = 30,
                     MovieTypeId = 1,
                     Year = 2001,
                 },
                 new Movie
                 {
                     MovieName = "Yüzüklerin Efendisi İkiz Kuleler",
                     DirectorId = 1,
                     Price = 20,
                     MovieTypeId = 1,
                     Year = 2002,
                 },
                new Movie
                {
                    MovieName = "Yüzüklerin Efendisi Kralın Dönüşü",
                    DirectorId = 1,
                    Price = 35,
                    MovieTypeId = 1,
                    Year = 2003,
                }
                );

            context.SaveChanges();

        }
    }
}
