using Microsoft.EntityFrameworkCore;
using WebApi.Entity;

namespace WebApi.DbOperations
{
    public interface IMovieStoreDbContext
    {
        public DbSet<Actor> Actors { get; set; }
        //public DbSet<Customer> Customers { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieType> MovieTypes { get; set; }
        public DbSet<OperationHistory> OperationHistories { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<FavoriteMovie> FavoriteMovies { get; set; }


        int SaveChanges();

    }
}
