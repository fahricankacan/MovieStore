using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Application.CustomerOperations.Command;
using WebApi.Application.CustomerOperations.Command.CreateToken;
using WebApi.Application.CustomerOperations.Command.Delete;
using WebApi.Application.CustomerOperations.Command.RefreshToken;
using WebApi.Application.CustomerOperations.Query.GetAll;
using WebApi.DbOperations;
using WebApi.TokenOperations.Models;
using static WebApi.Application.CustomerOperations.Command.CustomerCreateCommand;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public CustomerController(IMovieStoreDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpGet]
        public  IActionResult GetCustomers()
        {
            CustomerGetAllQuery query = new CustomerGetAllQuery(_mapper, _context);

            var result = query.Handle();

           return Ok(result);
        }
       

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CustomerCreateModel model)
        {
            CustomerCreateCommand command = new(_mapper,_context);

            command.Model = model;
            command.Handle();

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteCustomer([FromQuery] int id)
        {
            CustomerDeleteCommand command = new CustomerDeleteCommand(_mapper, _context);

            command.ModelId = id;

            command.Handle();

            return Ok();
        }

      

        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenViewModel login)
        {
            CreateTokenCommand command = new(_context, _mapper, _configuration);
            command.Model = login;
            var token = command.Handle();
            return token;

        }
        [HttpPost("refreshToken")]
        public ActionResult<Token> RefreshToken([FromQuery] string token)
        {
            RefreshTokenCommand command = new(_context, _mapper, _configuration);
            command.RefreshToken = token;
            var resultToken = command.Handle();
            return resultToken;

        }
    }
}
