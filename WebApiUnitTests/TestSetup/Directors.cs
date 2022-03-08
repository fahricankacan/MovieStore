using WebApi.DbOperations;
using WebApi.Entity;

namespace WebApiUnitTests.TestSetup
{

    public static class Directors
    {
        public static void AddDirectors(this MovieStoreDbContext context)
        {
            context.Directors.AddRange(
                new Director
                {
                    Name = "Peter",
                    Surname = "Jackson"
                });

            context.SaveChanges();
        }
    }

}
