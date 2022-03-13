using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entity
{
    public class OperationHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; } 
        //public decimal Price { get; set; }
        public DateTime DateTime { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public bool Delete { get; set; } = false;
    }
}
