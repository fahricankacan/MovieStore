using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.CustomerOperations.Command.CreateToken;
using WebApi.DbOperations;
using WebApiUnitTests.TestSetup;
using Xunit;

namespace WebApiUnitTests.Application.CustomerOperations.Command.CreateToken
{
    public class CreateTokenCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public CreateTokenCommandTest(CommonTestFixture commonTestFixture)
        {
            _mapper = commonTestFixture.Mapper;
            _context = commonTestFixture.Context;
         
        }

        //[Fact]
        //public void WhenUserIsExist_Model_RetrunToken() 
        //{
        //    CreateTokenCommand command = new CreateTokenCommand(_context, _mapper, _configuration);
        //    var user = _context.Customers.First();


        //    command.Model = new CreateTokenViewModel { Email = user.Email, Password = user.Password };

        //    var token = command.Handle();

        //    token.Should().NotBeNull();
        //}
        
        [Fact]
        public void WhenUserIsNotExist_Model_ThrowException() 
        {
            CreateTokenCommand command = new CreateTokenCommand(_context, _mapper, null);
            var user = _context.Customers.First();


            command.Model = new CreateTokenViewModel { Email = "lskfgspfd@gmskfms.com", Password = "123123"};

            FluentActions
                 .Invoking(() =>  command.Handle())
                 .Should()
                 .Throw<InvalidOperationException>("Kullanıcı Adı veya Şifre Hatalı!");
        }




    }
}
