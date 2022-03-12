using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.MovieOperations.Command.Create;
using WebApi.DbOperations;
using WebApi.Entity;
using WebApiUnitTests.TestSetup;
using Xunit;

namespace WebApiUnitTests.Application.MovieOperations.Command
{
    public class MovieCreateCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public MovieCreateCommandTest(CommonTestFixture commonTestFixture)
        {
            _mapper = commonTestFixture.Mapper;
            _context = commonTestFixture.Context;
        }


        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldBeCreated()
        {

            MovieCreateCommand command = new MovieCreateCommand(_context, _mapper);

            command.CreateModel = new MovieCreateCommand.MovieCreateModel
            {
                MovieActorsId = new List<int> { 1, 2, 3 },
                MovieName = "Test",
                MovieTypeId = 1,
                Price = 200,
                Year = 1998,
                DirectorId = 1
            };

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var movie = _context.Movies.SingleOrDefault(p => p.MovieName == command.CreateModel.MovieName);

            movie.Should().NotBeNull();
            movie.MovieActors.Select(p => p.ActorId).ToList().Should().BeEquivalentTo(command.CreateModel.MovieActorsId);
            movie.MovieName.Should().Be(command.CreateModel.MovieName);
            movie.MovieTypeId.Should().Be(command.CreateModel.MovieTypeId);
            movie.Price.Should().Be(command.CreateModel.Price);
            movie.Year.Should().Be(command.CreateModel.Year);

        }

        
        [Fact]
        public void WhenSameMovieIsExit_MovieName_ThrowException()
        {

            MovieCreateCommand command = new MovieCreateCommand(_context, _mapper);

            command.CreateModel = new MovieCreateCommand.MovieCreateModel
            {
                DirectorId=1,
                MovieActorsId = new List<int> { 1, 2, 3 },
                MovieName = "Test",
                MovieTypeId = 1,
                Price = 200,
                Year = 1998
            };

            command.Handle();

            MovieCreateCommand command2 = new(_context, _mapper);

            var model2 = new MovieCreateCommand.MovieCreateModel
            {
                DirectorId=1,
                MovieActorsId = new List<int> { 1, 2, 3 },
                MovieName = "Test",
                MovieTypeId = 1,
                Price = 200,
                Year = 1998
            };

            command2.CreateModel = model2;

            FluentActions.Invoking(() => command2.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Flim daha önce eklenmiş.");
        }
    }
}
