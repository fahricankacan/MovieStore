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
    public class CustomerDeleteCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CustomerDeleteCommandTest(CommonTestFixture commonTestFixture)
        {
            _mapper = commonTestFixture.Mapper;
            _context = commonTestFixture.Context;
        }


        [Fact]
        public void AfterDeletedEntityShouldNotFound_ModelId_RetrunsNull()
        {
            CustomerDeleteCommand command = new CustomerDeleteCommand(_mapper, _context);

            var entityEntry = _context.Customers.Add(new WebApi.Entity.Customer
            {
                Email = "testtest@testtest.com",
                Password = "123456",
                FavoriteMovies = null,
                Name = "testfako",
                Surname = "surtestfako",
                OperationHistories = null,
            });

            _context.SaveChanges();

            var customer = _context.Customers.SingleOrDefault(p => p.Id == entityEntry.Entity.Id);
            command.ModelId = customer.Id;
            command.Handle();


            var afterDelete = _context.Customers.SingleOrDefault(p => p.Id == entityEntry.Entity.Id);

            afterDelete.Should().BeNull();

        }

        [Fact]
        public void WhenIdIsNotFound_ModelId_ThrowException()
        {
            CustomerDeleteCommand command = new CustomerDeleteCommand(_mapper, _context);

            var entityEntry = _context.Customers.Add(new WebApi.Entity.Customer
            {
                Email = "testtest@testtest.com",
                Password = "123456",
                FavoriteMovies = null,
                Name = "testfako",
                Surname = "surtestfako",
                OperationHistories = null,
            });

            _context.SaveChanges();

            var customer = _context.Customers.SingleOrDefault(p => p.Id == entityEntry.Entity.Id);
            command.ModelId = customer.Id;

            _context.Customers.Remove(customer);
            _context.SaveChanges();


            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>("Kullanıcı bulunamadı.");

        }

    }
}
