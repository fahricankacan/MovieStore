using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.CustomerOperations.Command.Delete;
using WebApi.DbOperations;
using WebApiUnitTests.TestSetup;
using Xunit;

namespace WebApiUnitTests.Application.CustomerOperations.Command.Delete
{
    public class CustomerDeleteCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CustomerDeleteCommandValidatorTest(CommonTestFixture commonTestFixture)
        {
            _mapper = commonTestFixture.Mapper;
            _context = commonTestFixture.Context;
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(null)]
        public void WhenIdIsNotGreaterThenZero_ModelId_ThrowException(int modelId)
        {
            CustomerDeleteCommand command = new(_mapper, _context);
            CustomerDeleteCommandValidator validator = new();

            command.ModelId = modelId;

            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

    }
}

