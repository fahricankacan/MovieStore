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

        public ICollection<MovieCustomer> MovieCustomers { get; set; }
        public ICollection<MovieType> FavoriteTypes { get; set; }
        public ICollection<OperationHistory> OperationHistories { get; set; }
    }
}
