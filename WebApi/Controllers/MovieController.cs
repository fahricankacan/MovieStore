using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Application.MovieOperations.Command.Create;
using WebApi.Application.MovieOperations.Command.Delete;
using WebApi.Application.MovieOperations.Command.Update;
using WebApi.Application.Queries.GetMovieById;
using WebApi.Application.Queries.GetMovies;
using WebApi.DbOperations;
using static WebApi.Application.MovieOperations.Command.Create.MovieCreateCommand;
using static WebApi.Application.MovieOperations.Command.Update.MovieUpdateCommand;
using static WebApi.Application.Queries.GetMovies.GetMoviesQuery;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        IMovieStoreDbContext _movieStoreDbContext;
        IMapper _mapper;


        public MovieController(IMovieStoreDbContext movieStoreDbContext, IMapper mapper)
        {
            _movieStoreDbContext = movieStoreDbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            GetMoviesQuery movie = new GetMoviesQuery(_mapper, _movieStoreDbContext);
            var result = movie.Handle(); /*_movieStoreDbContext.Movies.Include(x => x.MovieActors).ThenInclude(x => x.Actors).ToList();*/



            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            GetMoviesByIdQuery query = new GetMoviesByIdQuery(_movieStoreDbContext, _mapper);
            GetMovieByIdQueryValidator validator = new GetMovieByIdQueryValidator();
            query.MovieId = id;

            validator.ValidateAndThrow(query);

            var result = query.Query();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] MovieCreateModel model)
        {
            MovieCreateCommand command = new(_movieStoreDbContext,_mapper);
            MovieCreateCommandValidator validator = new();
            command.CreateModel = model;

            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateMovie([FromBody]MovieUpdateModel model , int id)
        {
            MovieUpdateCommand command = new MovieUpdateCommand(_movieStoreDbContext,_mapper);
            MovieUpdateCommandValidator validate = new();
            command.ModelId = id;
            command.UpdateModel = model;

            validate.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteMovie([FromQuery] int id)
        {
            MovieDeleteCommand command = new(_movieStoreDbContext, _mapper);
            command.ModelId = id;

            command.Handle();
            

            return Ok();
         }
    }
}
