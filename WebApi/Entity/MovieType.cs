using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entity
{
    public class MovieType 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string Type { get; set; }

        public ICollection<Movie> Movie { get; set; }
    }
}
