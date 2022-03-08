using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Application.MovieOperations.Command.Delete
{
    public class MovieDeleteCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

       
        public int ModelId { get; set; }

        public MovieDeleteCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public void Handle()
        {
            var movie = _context.Movies.SingleOrDefault(p => p.Id == ModelId);

            if(movie is null)
            {
                throw new InvalidOperationException("Flim bulunamadı.");
            }

            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
    }
}
