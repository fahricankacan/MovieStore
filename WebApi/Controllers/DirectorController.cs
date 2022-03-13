using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Application.DirectorOperations.Query.DirectorGetAll;
using WebApi.Application.DirectorOperations.Query.DirectorGetById;
using WebApi.DbOperations;
using FluentValidation;
using static WebApi.Application.DirectorOperations.Command.Add.DirectorCreateCommand;
using WebApi.Application.DirectorOperations.Command.Add;
using WebApi.Application.DirectorOperations.Command.Update;
using static WebApi.Application.DirectorOperations.Command.Update.DirectorUpdateCommand;
using WebApi.Application.DirectorOperations.Command.Delete;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;

        public DirectorController(IMovieStoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            DirectorGetAllQuery query = new DirectorGetAllQuery(_context);

            return Ok(query.Hanlde());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            DirectorGetByIdQuery query = new(_context);
            DirectorGetByIdQueryValidator validator = new();

            query.ModelId = id;

            validator.ValidateAndThrow(query);

            var result = query.Hanlde();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] DirectorCreateModel model)
        {
            DirectorCreateCommand command = new(_context);
            DirectorCreateCommandValidator validator = new();

            command.Model = model;

            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] DirectorUpdateModel model,[FromQuery] int id)
        {
            DirectorUpdateCommand command = new(_context);
            DirectorUpdateCommandValidator validator = new();

            command.Model = model;
            command.ModelId = id;

            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpDelete]
        public  IActionResult Delete([FromQuery]int id)
        {
            DirectorDeleteCommand command = new DirectorDeleteCommand(_context);
            DirectorDeleteCommanValidator validator = new();

            command.ModelId = id;

            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }
    }
}
