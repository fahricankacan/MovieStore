using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entity;

namespace WebApi.Application.CustomerOperations.Query.GetAll
{
    public class CustomerGetAllQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CustomerGetAllModel Model { get; set; }

        public CustomerGetAllQuery(IMapper mapper, IMovieStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;

        }

        public List<CustomerGetAllModel> Handle()
        {
            List<CustomerGetAllModel> customerList = new();

            var customers = _context.Customers
                .Include(x => x.FavoriteMovies).ThenInclude(y=>y.Movie)
                .Include(x => x.OperationHistories).ThenInclude(y=>y.Movie);

            foreach (var customer in customers)
            {
                customerList.Add(new CustomerGetAllModel
                {
                    Id = customer.Id,
                    FavoriteMovies = customer.FavoriteMovies.Select(p => p.Movie.MovieName).ToList(),
                    Name = customer.Name,
                    Surname = customer.Surname,
                    OperationHistories = customer.OperationHistories.Select(p => new { p.Movie.MovieName, p.Movie.Price, p.DateTime, p.Id }).ToList(),
                    Email=customer.Email
                }); 
            }

            return customerList;
        }

        public class CustomerGetAllModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Email { get; set; }


            public ICollection<String> FavoriteMovies { get; set; }
            public object OperationHistories { get; set; }
        }

        public class OperationHistoryModel
        {
            public int Id { get; set; }
            public decimal Price { get; set; }
            public DateTime Datetime { get; set; }
        }
    }
}
