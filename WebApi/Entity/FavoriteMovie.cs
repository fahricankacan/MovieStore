using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entity
{
    public class FavoriteMovie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public int MovieId { get; set; }

        public int CustomerId { get; set; }
        ICollection<Customer> Customers { get; set; }
    }
}
