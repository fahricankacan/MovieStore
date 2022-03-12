using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ActorOperations.Command;
using WebApi.Application.ActorOperations.Command.Delete;
using WebApi.Application.ActorOperations.Command.Update;
using WebApi.Application.ActorOperations.Query.GetAll;
using WebApi.Application.ActorOperations.Query.GetById;
using WebApi.DbOperations;
using static WebApi.Application.ActorOperations.Command.ActorCreateCommand;
using static WebApi.Application.ActorOperations.Command.ActorUpdateCommand;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;

        public ActorController(IMovieStoreDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            ActorGetAllQuery query = new(_context);

            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById( int id)
        {
            ActorGetByIdQuery query = new(_context);
            ActorGetByIdQueryValidator validator = new();

            query.ModelId = id;

            validator.ValidateAndThrow(query);

            var result = query.Handle();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ActorCreateModel model)
        {
            ActorCreateCommand command = new(_context);
            ActorCreateCommandValidator validator = new();

            command.Model = model;
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ActorDeleteCommand command = new(_context);
            ActorDeleteCommandValidator validator = new();

            command.ModelId = id;

            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();

        }

        [HttpPut]
        public IActionResult Update(int id, [FromBody] ActorUpdateModel model)
        {
            ActorUpdateCommand command = new(_context);
            ActorUpdateCommandValidator validator = new();

            command.Model = model;
            command.ModelId = id;

            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();

        }
    }
}
