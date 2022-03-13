using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entity;

namespace WebApi.Application.CustomerOperations.Command.Buy
{
    public class CustomerBuyCommand
    {
        private readonly IMovieStoreDbContext _context;

        public BuyCommandModel Model { get; set; }
      

        public CustomerBuyCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Model.BuyedMoiveId);
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Model.CustomerId);

            if(movie is null && customer is null)
            {
                throw new InvalidOperationException("Beklenmeyen hata.");
            }

            OperationHistory history = new OperationHistory
            {
                Customer = customer,
                Movie = movie,
                DateTime = DateTime.Now,
            };

            _context.OperationHistories.Add(history);

            _context.SaveChanges();
           
        }

        public class BuyCommandModel
        {
            public int BuyedMoiveId { get; set; }
            public int CustomerId { get; set; }
        }
    }
}
