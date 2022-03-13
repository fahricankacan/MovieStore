using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entity;

namespace WebApi.Application.DirectorOperations.Query.DirectorGetById
{
    public class DirectorGetByIdQuery
    {
        private readonly IMovieStoreDbContext _context;
        public int ModelId { get; set; }

        public DirectorGetByIdQuery(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public DirectorGetByIdModel Hanlde()
        {
            var director = _context.Directors.Include(x => x.DirectedMovies).SingleOrDefault(p => p.Id == ModelId);

            if (director is null)
            {
                throw new InvalidOperationException("Yönetmen bulunamadı.");
            }

            return new DirectorGetByIdModel
            {
                Id = director.Id,
                Name = director.Name,
                Surname = director.Surname,
                DirectedMovies = director.DirectedMovies
                .Select(
                    p => new DirectorMovieDetailModel
                    { Id = p.Id, MovieName = p.MovieName, Price = p.Price, Year = p.Year })
                .ToList()
            };

        }

        public class DirectorGetByIdModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }

            public ICollection<DirectorMovieDetailModel> DirectedMovies { get; set; }
        }

        public class DirectorMovieDetailModel
        {
            public int Id { get; set; }
            public string MovieName { get; set; }
            public int Year { get; set; }
            public decimal Price { get; set; }
        }
    }
}
