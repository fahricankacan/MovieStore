using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entity
{
    public class Movie
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public DateTime Year { get; set; }
        
        public MovieType Type { get; set; }      
        public Director Director { get; set; }
        public List<Actor> Actors { get; set; }
        public decimal Price { get; set; }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name  { get; set; }
        public string Surname { get; set; }
        public List<Movie> Movies { get; set; }
        public List<MovieType> FavoriteTypes { get; set; }
    }

    public class MovieType 
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class OperationHistory
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public decimal Price { get; set; }
        public DateTime DateTime { get; set; }
    }
}
