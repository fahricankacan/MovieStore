using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entity
{
    public class MovieType 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string Type { get; set; }

        public Movie Movie { get; set; }
    }
}
