using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        IMovieStoreDbContext _movieStoreDbContext;

        public MovieController(IMovieStoreDbContext movieStoreDbContext)
        {
            _movieStoreDbContext = movieStoreDbContext;
        }

        [HttpGet]
        public IActionResult Movies()
        {
            var result = _movieStoreDbContext.Movies.Include(x => x.MovieActors).ThenInclude(x => x.Actors).ToList();

            var a = new
            {
                name = result[0].MovieActors.ToList()[0].Actors.Name
            };

            return Ok(a);
        }
    }
}
