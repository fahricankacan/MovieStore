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

namespace WebApiUnitTests.Application.MovieOperations.Queries
{
    public class GetById : IClassFixture<CommonTestFixture>
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetById(CommonTestFixture commonTestFixture)
        {
            _mapper = commonTestFixture.Mapper;
            _context = commonTestFixture.Context;
        }


        [Fact]
        public void WhenBookIdIsNotFount_Id_ShouldThrowException()
        {
            GetMoviesByIdQuery query = new GetMoviesByIdQuery(_context, _mapper);
            query.MovieId = 543;

            FluentActions
                .Invoking(() => query.Query())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Flim bulunamadı.");

        }
    }
}
