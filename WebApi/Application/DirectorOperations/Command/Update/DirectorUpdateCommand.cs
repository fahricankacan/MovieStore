using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Application.DirectorOperations.Command.Update
{
    public class DirectorUpdateCommand
    {
        private readonly IMovieStoreDbContext _context;

        public DirectorUpdateModel Model { get; set; }
        public int ModelId { get; set; }

        public DirectorUpdateCommand(IMovieStoreDbContext context)
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

            director.Name = Model.Name;
            director.Surname = Model.Surname;


            //if(Model.DirectedMovieIds is not null)
            //{
            //    foreach (var id in Model.DirectedMovieIds)
            //    {
            //        var movie = _context.Movies.SingleOrDefault(p => p.Id == id);
            //        director.DirectedMovies.Add(movie);
            //    }
            //}

            _context.SaveChanges();
           
        }

        public class DirectorUpdateModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }

            //public ICollection<int> DirectedMovieIds { get; set; }
        }
    }

}
