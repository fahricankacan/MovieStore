using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entity;

namespace WebApiUnitTests.TestSetup
{
    public static class MovieTypes
    {
        public static void AddMovieTypes(this MovieStoreDbContext context)
        {
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
        }
    }
}
