using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entity;

namespace WebApi.Application.CustomerOperations.Command
{
    public class CustomerCreateCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CustomerCreateModel Model{ get; set; }
        

        public CustomerCreateCommand(IMapper mapper, IMovieStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
            
        }

        public void Handle()
        {

            var customer = _context.Customers.SingleOrDefault(p => p.Email==Model.Email);
            if(customer is not null)
            {
                throw new InvalidOperationException("Kullanıcı daha önce kayıt olmuş.");
            }

            customer = new Customer { Name = Model.Name, Surname = Model.Surname,Email=Model.Email,Password=Model.Password };

            if(Model.FavoriteMovieIds is not null)
            {
                List<FavoriteMovie> favoriteMovieList = new List<FavoriteMovie>();
                foreach (var id in Model.FavoriteMovieIds)
                {
                    favoriteMovieList.Add(new FavoriteMovie { MovieId = id });
                }
                customer.FavoriteMovies = favoriteMovieList;

            }

            _context.Customers.Add(customer);
            _context.SaveChanges();

        } 

        public class CustomerCreateModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }

            public ICollection<int> FavoriteMovieIds { get; set; }
            
        }
    }
}
