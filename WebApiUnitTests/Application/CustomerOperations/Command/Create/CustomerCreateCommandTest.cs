using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.CustomerOperations.Command;
using WebApi.DbOperations;
using WebApiUnitTests.TestSetup;
using Xunit;
using static WebApi.Application.CustomerOperations.Command.CustomerCreateCommand;

namespace WebApiUnitTests.Application.CustomerOperations.Command
{
    public class CustomerCreateCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CustomerCreateCommandTest(CommonTestFixture commonTestFixture)
        {
            _mapper = commonTestFixture.Mapper;
            _context = commonTestFixture.Context;
        }

        [Fact]
        public void WhenUserExist_Model_ThrowEmailExistError()
        {
            CustomerCreateCommand command = new CustomerCreateCommand(_mapper, _context);

            command.Model = new CustomerCreateModel
            {
                Email = "test211@gmail.com",
                Name = "test22",
                Password = "123456",
                Surname = "test23",
                FavoriteMovieIds = null
            };

            command.Handle();

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kullanıcı daha önce kayıt olmuş.");


        }
    
    }}
