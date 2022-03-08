using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Queries.GetMovieById;
using WebApi.DbOperations;
using WebApiUnitTests.TestSetup;
using Xunit;

namespace WebApiUnitTests.Application.Movie.Queries
{
    public class GetByIdValidator : IClassFixture<CommonTestFixture>
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetByIdValidator(CommonTestFixture commonTestFixture)
        {
            _mapper = commonTestFixture.Mapper;
            _context = commonTestFixture.Context;
        }


        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void WhenIdIsNotGreaterThanZero_Id_ShouldThrowException(int id)
        {
            GetMoviesByIdQuery query = new GetMoviesByIdQuery(_context, _mapper);
            query.MovieId = id;

            GetMovieByIdQueryValidator validate = new();

            var result = validate.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);

        }
    }
}
