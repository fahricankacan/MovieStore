using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Application.ActorOperations.Command.Delete
{
    public class ActorDeleteCommand
    {
        private readonly IMovieStoreDbContext _context;

        public int ModelId { get; set; }

        public ActorDeleteCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var actor = _context.Actors.SingleOrDefault(p => p.Id == ModelId);

            if(actor is null)
            {
                throw new InvalidOperationException("Aktör mevcut değil.");
            }

            _context.Actors.Remove(actor);
            _context.SaveChanges();
        }
    }
}
