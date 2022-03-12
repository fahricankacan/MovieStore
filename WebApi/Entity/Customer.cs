using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entity
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string Name  { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpireDate { get; set; }

        //public ICollection<MovieCustomer> MovieCustomers { get; set; }
        public ICollection<FavoriteMovie> FavoriteMovies { get; set; }
        public ICollection<OperationHistory> OperationHistories { get; set; }
    }
}
