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
                   new WebApi.Entity.Customer { Name = "Fahrican", Surname = "Kaçan", Email = "fahrican.kcn@gmail.com", Password = "123456" },
                   new WebApi.Entity.Customer { Name = "Feyza", Surname = "Kaçan", Email = "feyza.kcn@gmail.com", Password = "123456" },
                   new WebApi.Entity.Customer { Name = "Lethesu", Surname = "Twtich", Email = "lethesu.kcn@gmail.com", Password = "123456" },
                   new WebApi.Entity.Customer { Name = "test", Surname = "test", Email = "test@test.com", Password = "123456" }
             );

            context.SaveChanges();
        }
    }
}
