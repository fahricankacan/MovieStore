using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Application.CustomerOperations.Command.Buy
{
    public class DeleteBuyedMovieCommand
    {
        private readonly IMovieStoreDbContext _context;

        public int OperationId { get; set; }

        public DeleteBuyedMovieCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        
        public void Handle()
        {
            var operation = _context.OperationHistories.FirstOrDefault(p => p.Id == OperationId);

            if(operation is null)
            {
                throw new InvalidOperationException("İşlem sırasında hata meydana geldi.");
            }

            operation.Delete = true;

            _context.SaveChanges();
        }

    }
}
