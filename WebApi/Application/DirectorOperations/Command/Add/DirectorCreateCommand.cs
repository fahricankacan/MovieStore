using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entity;

namespace WebApi.Application.DirectorOperations.Command.Add
{
    public class DirectorCreateCommand
    {
        private readonly IMovieStoreDbContext _context;

        public DirectorCreateModel Model { get; set; }

        public DirectorCreateCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var director = _context.Directors.SingleOrDefault(p => p.Name + " " + p.Surname == Model.Name + " " + Model.Surname);
            if(director is not null)
            {
                throw new InvalidOperationException("Yönetmen zaten kayıtlı.");
            }

            director = new Director { Name = Model.Name, Surname = Model.Surname,DirectedMovies=new List<Movie>() };

            if(Model.DirectedMoviesId is not null)
            {
                List<Movie> movieList = new();

                foreach (var id in Model.DirectedMoviesId)
                {
                    var movie = _context.Movies.SingleOrDefault(p => p.Id == id);
                    director.DirectedMovies.Add(movie);
                }
            }

            _context.Directors.Add(director);
            _context.SaveChanges();
        }

        public class DirectorCreateModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }

            public ICollection<int> DirectedMoviesId { get; set; }
        }
    }
}
