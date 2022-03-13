using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Application.DirectorOperations.Command.Delete
{
    public class DirectorDeleteCommand
    {
        private readonly IMovieStoreDbContext _context;
        public int ModelId { get; set; }

        public DirectorDeleteCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var director = _context.Directors.SingleOrDefault(p => p.Id == ModelId);

            if(director is null)
            {
                throw new InvalidOperationException("Yönetmen bulunamadı.");
            }

            _context.Directors.Remove(director);
            _context.SaveChanges();

        }
    }
}
