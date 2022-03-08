using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApiUnitTests.TestSetup
{
    public static class Customer
    {
        public static void AddCustomers(this MovieStoreDbContext context)
        {
            context.Customers.AddRange(
                 new WebApi.Entity.Customer { Name = "Fahrican", Surname = "Kaçan" },
                 new WebApi.Entity.Customer { Name = "Feyza", Surname = "Kaçan" },
                 new WebApi.Entity.Customer { Name = "Lethesu", Surname = "Twtich" }
             );

            context.SaveChanges();
        }
    }
}
