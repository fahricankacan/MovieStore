using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entity
{
    public class MovieActor
    {
  
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public Actor Actors { get; set; }
        public int ActorId { get; set; }
       
    }
}
