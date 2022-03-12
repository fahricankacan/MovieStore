using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entity;

namespace WebApiUnitTests.TestSetup
{
    public static class OperationHistorie
    {
        public static void AddOperationHistories(this MovieStoreDbContext context)
        {
            context.OperationHistories.AddRange(
                    new OperationHistory { CustomerId = 1, MovieId = 1, DateTime = DateTime.Now.AddDays(-2) },
                    new OperationHistory { CustomerId = 1, MovieId = 2, DateTime = DateTime.Now.AddDays(-2) },
                    new OperationHistory { CustomerId = 1, MovieId = 3, DateTime = DateTime.Now.AddDays(-2) },
                    new OperationHistory { CustomerId = 3, MovieId = 2, DateTime = DateTime.Now.AddDays(-2) }
                    );

            context.SaveChanges();
        }
    }
}
