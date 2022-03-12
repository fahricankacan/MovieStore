using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entity;

namespace WebApi.DbOperations
{
    public class MovieStoreDbContext:DbContext,IMovieStoreDbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieActor>()
        .HasKey(bc => new { bc.MovieId , bc.ActorId});
            modelBuilder.Entity<MovieActor>()
                .HasOne(bc => bc.Movie)
                .WithMany(b => b.MovieActors)
                .HasForeignKey(bc => bc.MovieId);
            modelBuilder.Entity<MovieActor>()
                .HasOne(bc => bc.Actors)
                .WithMany(c => c.MovieActors)
                .HasForeignKey(bc => bc.ActorId);

            //       modelBuilder.Entity<MovieCustomer>()
            //.HasKey(bc => new { bc.MovieId, bc.CustomerId });
            //       modelBuilder.Entity<MovieCustomer>()
            //           .HasOne(bc => bc.Movie)
            //           .WithMany(b => b.Movie)
            //           .HasForeignKey(bc => bc.MovieId);
            //       modelBuilder.Entity<MovieCustomer>()
            //           .HasOne(bc => bc.Customer)
            //           .WithMany(c => c.MovieCustomers)
            //           .HasForeignKey(bc => bc.CustomerId);

            //modelBuilder.Entity<CustomerFavoriteMovie>()
            //    .HasKey(cf => new { cf.CustomerId, cf.FavoriteMovieId });
            //modelBuilder.Entity<CustomerFavoriteMovie>()
            //    .HasOne(cf => cf.Customer)
            //    .WithMany(c => c.CustomerFavoriteMovies);
            //modelBuilder.Entity<CustomerFavoriteMovie>()
            //   .HasOne(cf => cf.FavoriteMovie)
            //   .WithMany(c => c.CustomerFavoriteMovies);
            
        }

        public MovieStoreDbContext(DbContextOptions<MovieStoreDbContext> options):base(options){}

        

        public DbSet<Actor> Actors{ get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Movie> Movies{ get; set; }
        public DbSet<MovieType> MovieTypes { get; set; }
        public DbSet<OperationHistory> OperationHistories { get; set; }
        public DbSet<MovieActor> MovieActors { get; set ; }
        //public DbSet<MovieCustomer> MovieCustomers { get; set; }
        public DbSet<FavoriteMovie> FavoriteMovies { get; set; }
        //public DbSet<MovieCustomer> MovieCustomers { get; set ; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
