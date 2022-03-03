using System.Collections.Generic;

namespace WebApi.Entity
{
    public class Director
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Movie> DirectedMovies { get; set; }
    }
}
