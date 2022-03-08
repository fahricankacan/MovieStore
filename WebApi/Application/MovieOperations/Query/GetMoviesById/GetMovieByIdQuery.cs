using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entity;
using static WebApi.Application.Queries.GetMovies.GetMoviesQuery;

namespace WebApi.Application.Queries.GetMovieById
{
    public class GetMoviesByIdQuery
    {
        private readonly IMovieStoreDbContext _movieStoreDbContext;
        private readonly IMapper _mapper;
        public int MovieId { get; set; }

        public GetMoviesByIdQuery(IMovieStoreDbContext movieStoreDbContext, IMapper mapper)
        {
            _movieStoreDbContext = movieStoreDbContext;
            _mapper = mapper;
        }


        public MovieModel Query()
        {
            var movieList = _movieStoreDbContext.Movies
               .Include(x => x.MovieType)
               .Include(x => x.Director)
               .Include(x => x.MovieActors)
               .ThenInclude(x => x.Actors)
               .FirstOrDefault(p=>p.Id == MovieId);
           
           if(movieList is null)
            {
                throw new InvalidOperationException("Flim bulunamadı.");
            }
            
           var a = _mapper.Map<MovieModel>(movieList);

            return a;
        }


        //public class MovieModel
        //{
        //    public string MovieName { get; set; }
        //    public int Year { get; set; }
        //    public decimal Price { get; set; }
        //    public string Type { get; set; }
        //    public string Director { get; set; }
        //    public List<string> ActorNames { get; set; }
        //}



    }
}
