using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Application.Queries.GetMovies
{
    public class GetMoviesQuery
    {
        private readonly IMovieStoreDbContext _movieStoreDbContext;
        private readonly IMapper _mapper;

        public GetMoviesQuery(IMapper mapper, IMovieStoreDbContext movieStoreDbContext)
        {
            _mapper = mapper;
            _movieStoreDbContext = movieStoreDbContext;
        }


        public List<MovieModel> Handle()
        {
            List<MovieModel> movieModelsList = new List<MovieModel>();

            var movieList = _movieStoreDbContext.Movies
                .Include(x => x.MovieType)
                .Include(x => x.Director)
                .Include(x => x.MovieActors)
                .ThenInclude(x => x.Actors)
                .OrderBy(x => x.Id).ToList();

            foreach (var movie in movieList)
            {
                movieModelsList.Add(_mapper.Map<MovieModel>(movie));
            }


            return movieModelsList;
        }

        public class MovieModel
        {
            public string MovieName { get; set; }
            public int Year { get; set; }
            public decimal Price { get; set; }
            public string Type { get; set; }
            public string Director { get; set; }
            public List<string> ActorNames { get; set; }

        }
    }
}
