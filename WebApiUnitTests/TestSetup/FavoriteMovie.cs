using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApiUnitTests.TestSetup
{
    public static class FavoriteMovie
    {
        public static void AddFavoriteMovies(this MovieStoreDbContext context)
        {
            context.FavoriteMovies.AddRange(
                      new WebApi.Entity.FavoriteMovie { MovieId = 1, CustomerId = 1 },
                      new WebApi.Entity.FavoriteMovie { MovieId = 2, CustomerId = 1 },
                      new WebApi.Entity.FavoriteMovie { MovieId = 3, CustomerId = 1 },
                      new WebApi.Entity.FavoriteMovie { MovieId = 1, CustomerId = 2 }
                      );

            context.SaveChanges();
        }
    }
}
