using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Application.DirectorOperations.Query.DirectorGetAll
{
    public class DirectorGetAllQuery
    {
        private readonly IMovieStoreDbContext _context;

        public DirectorGetAllQuery(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public IEnumerable<DirectorGetAllModel> Hanlde()
        {
            var directors = _context.Directors.Include(x => x.DirectedMovies).OrderBy(x => x.Id);



            List<DirectorGetAllModel> directorList = new();
            directorList.AddRange(directors.Select(p => new DirectorGetAllModel
            {
                Name = p.Name,
                Id = p.Id,
                Surname = p.Surname,
                DirectedMovies = p.DirectedMovies
                .Select(
                    x => new DirectorMovieDetailModel
                    {
                        Id = x.Id,
                        MovieName = x.MovieName,
                        Price = x.Price,
                        Year = x.Year
                    }).ToList()
            }));


            return directorList;

            //return new List<DirectorGetByIdModel>
            //{
            //    Id = director.Id,
            //    Name = director.Name,
            //    Surname = director.Surname,
            //    DirectedMovies = director.DirectedMovies
            //    .Select(
            //        p => new DirectorMovieDetailModel
            //        { Id = p.Id, MovieName = p.MovieName, Price = p.Price, Year = p.Year })
            //    .ToList()
            //};
        }
        public class DirectorGetAllModel
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
