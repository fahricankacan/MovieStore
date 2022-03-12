using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Application.CustomerOperations.Delete
{
    public class CustomerDeleteCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public int ModelId { get; set; }

        public CustomerDeleteCommand(IMapper mapper, IMovieStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;

        }

        public void Handle()
        {
            var customer = _context.Customers.SingleOrDefault(p => p.Id == ModelId);

            if(customer is null)
            {
                throw new InvalidOperationException("Kullanıcı bulunamadı.");
            }

            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}
