using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.MovieOperations.Command.Create;
using WebApi.DbOperations;
using WebApiUnitTests.TestSetup;
using Xunit;
using static WebApi.Application.MovieOperations.Command.Create.MovieCreateCommand;

namespace WebApiUnitTests.Application.MovieOperations.Command.Create
{
    public class MovieCreateCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        private List<int> _movieActorId;


        public MovieCreateCommandValidatorTest(CommonTestFixture commonTestFixture)
        {
            _mapper = commonTestFixture.Mapper;
            _context = commonTestFixture.Context;
            _movieActorId = new List<int>() { 1, 2, 3 };
        }

        [Theory]
        [MemberData(nameof(MovieCreateCommandValidatorTestData.Null_Parameter_Test_Data)
            , MemberType = typeof(MovieCreateCommandValidatorTestData))]
        public void CheckIfParametrsAreNull_MovieCreateModel_ThrowException(
            int directorId, string movieName, int movieTypeId, decimal price, int year
            , IEnumerable<int> movieActorId)
        {
            MovieCreateCommand command = new MovieCreateCommand(_context, _mapper);
            MovieCreateCommandValidator validate = new MovieCreateCommandValidator();

            command.CreateModel = new MovieCreateModel
            {
                DirectorId = directorId,
                MovieActorsId = (ICollection<int>)movieActorId,
                MovieName = movieName,
                MovieTypeId = movieTypeId,
                Price = price,
                Year = year
            };

            var result = validate.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }


        [Theory]
        [MemberData(nameof(MovieCreateCommandValidatorTestData.Greater_Than_Zero_Test_Data)
         , MemberType = typeof(MovieCreateCommandValidatorTestData))]
        public void CheckIfParametrsAreNotGreaterThanZero_MovieCreateModel_ThrowException(
         int directorId, string movieName, int movieTypeId, decimal price, int year
         , IEnumerable<int> movieActorId)
        {
            MovieCreateCommand command = new MovieCreateCommand(_context, _mapper);
            MovieCreateCommandValidator validate = new MovieCreateCommandValidator();

            command.CreateModel = new MovieCreateModel
            {
                DirectorId = directorId,
                MovieActorsId = (ICollection<int>)movieActorId,
                MovieName = movieName,
                MovieTypeId = movieTypeId,
                Price = price,
                Year = year
            };

            var result = validate.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }

    }

    public class MovieCreateCommandValidatorTestData
    {
        public static IEnumerable<object[]> Null_Parameter_Test_Data => new List<object[]>
        {
            new object[]{null,"Test",1,222,1998,new List<int> { 1, 2, 3 } },
            new object[]{1,null,1,222,1998,new List<int> { 1, 2, 3 } },
            new object[]{1,"Test",null,null,1998,new List<int> { 1, 2, 3 } },
            new object[]{1,"Test",1,222,null,new List<int> { 1, 2, 3 } },
            new object[]{1,"Test",1,222,1998,null },

        }; 
        public static IEnumerable<object[]> Greater_Than_Zero_Test_Data => new List<object[]>
        {
            new object[]{0,"Test",1,222,1998,new List<int> { 1, 2, 3 } },
            new object[]{1,"Te",-1,222,1998,new List<int> { 1, 2, 3 } },
            new object[]{1,"Test",0,22,1998,new List<int> { 1, 2, 3 } },
            new object[]{1,"Test",1,222,0,new List<int> { 1, 2, 3 } },
            new object[]{1,"Test",1,222,1998,new List<int> { 0,-1,-2 } },
        };
    }
}
