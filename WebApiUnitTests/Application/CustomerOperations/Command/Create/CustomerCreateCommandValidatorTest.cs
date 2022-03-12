using AutoMapper;
using FluentAssertions;
using System;
using System.Collections;
using System.Collections.Generic;
using WebApi.Application.CustomerOperations.Command;
using WebApi.Application.CustomerOperations.Command.Create;
using WebApi.DbOperations;
using WebApiUnitTests.TestSetup;
using Xunit;
using static WebApi.Application.CustomerOperations.Command.CustomerCreateCommand;

namespace WebApiUnitTests.Application.CustomerOperations.Command
{
    public class CustomerCreateCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CustomerCreateCommandValidatorTest(CommonTestFixture commonTestFixture)
        {
            _mapper = commonTestFixture.Mapper;
            _context = commonTestFixture.Context;
        }

        [Theory]
        [MemberData(nameof(CustomerCreateCommandValidatorTestData.Null_Parameter_Test_Data)
            ,MemberType =typeof(CustomerCreateCommandValidatorTestData))]
        public void WhenModelPropertyIsNull_Model_ThrowEmailExistError(string email,string password,string name,string surname,
            IEnumerable<int> favoriteMovie)
        {
            CustomerCreateCommand command = new CustomerCreateCommand(_mapper, _context);
            CustomerCreateCommandValidator validator = new();

            command.Model = new CustomerCreateModel
            {
                Email =email,
                Name = name,
                Password = password,
                Surname = surname,
                FavoriteMovieIds = (ICollection<int>)favoriteMovie
            };

            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);

        }
        [Theory]
        [MemberData(nameof(CustomerCreateCommandValidatorTestData.Null_Parameter_Test_Data)
            ,MemberType =typeof(CustomerCreateCommandValidatorTestData))]
        public void CheckInputIsValid_Model_ThrowEmailExistError(string email,string password,string name,string surname,
            IEnumerable<int> favoriteMovie)
        {
            CustomerCreateCommand command = new CustomerCreateCommand(_mapper, _context);
            CustomerCreateCommandValidator validator = new();

            command.Model = new CustomerCreateModel
            {
                Email =email,
                Name = name,
                Password = password,
                Surname = surname,
                FavoriteMovieIds = (ICollection<int>)favoriteMovie
            };

            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);

        }


        public class CustomerCreateCommandValidatorTestData
        {
            public static IEnumerable<object[]> Null_Parameter_Test_Data => new List<object[]>
            {
                new object[]{ "test1@gmail.com","fa","test22","test23",new List<int> { 1, 2 } },
                new object[]{ "testasda","123456","test22","test23",new List<int> { 1, 2 } },
                new object[]{ "test1@gmail.com","2", "test22", "test23",new List<int> { 1, 2 } },
                new object[]{ "test1@gmail.com","123456123124124123","test22", null, new List<int> { 1, 2 } },
                new object[]{ "test1@gmail.com","123456","te","t3", new List<int> { -1,2,-4 } },
            };
        }

    }
}
