using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Application.ActorOperations.Command
{
    public class CreateActorCommand
    {
        IMovieStoreDbContext _movieStoreDbContext;
     


        public CreateActorCommand(IMovieStoreDbContext movieStoreDbContext)
        {
            _movieStoreDbContext = movieStoreDbContext;
            
        }

        public void Handle()
        {

        }


        public class Actor
        {
            public string Name { get; set; }
            public string Surname { get; set; }
        }
    }
}
