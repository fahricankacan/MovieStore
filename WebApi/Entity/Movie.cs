using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entity
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string MovieName { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }


        public int MovieTypeId { get; set; }
        public MovieType MovieType { get; set; }

        public int DirectorId { get; set; }
        public Director Director { get; set; }

        public ICollection<MovieActor> MovieActors { get; set; }
      

        public bool IsActive { get; set; } = true;
    }
}
