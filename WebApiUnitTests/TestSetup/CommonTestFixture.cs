using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Utilitys;

namespace WebApiUnitTests.TestSetup
{
    public class CommonTestFixture
    {
        public MovieStoreDbContext Context { get; set; }
        public IMapper Mapper { get; set; }
        

        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<MovieStoreDbContext>().
                UseInMemoryDatabase(databaseName: "MovieStoreTestDB").Options;
            Context = new MovieStoreDbContext(options);
            Context.Database.EnsureCreated();
            Context.AddDirectors();
            Context.AddMovieActors();
            Context.AddDirectors();
            Context.AddDirectors();
            Context.AddFavoriteMovies();
            Context.AddCustomers();
            Context.AddOperationHistories();
            Context.AddMovies();
            Context.AddMovieTypes();
            Context.AddActors();

            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfiles>()).CreateMapper();


        }
    }
}
