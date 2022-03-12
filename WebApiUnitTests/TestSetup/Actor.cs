using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApiUnitTests.TestSetup
{
    public static class Actor
    {
        public static void AddActors(this MovieStoreDbContext context)
        {
            context.Actors.AddRange
                    (
                    new WebApi.Entity.Actor { Name = "Elijah", Surname = "Wood" },
                    new WebApi.Entity.Actor { Name = "Viggo", Surname = "Mortensen" },
                    new WebApi.Entity.Actor { Name = "Sean", Surname = "Astin" },
                    new WebApi.Entity.Actor { Name = "Orlando", Surname = "Bloom" },
                    new WebApi.Entity.Actor { Name = "Ian", Surname = "McKellen" }
                    );
            context.SaveChanges();
        }
    }
}
