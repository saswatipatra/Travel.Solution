using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.Models
{
    [Table("destinations")]
    public class Destination
    {
        [Key]
        public int DestinationId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        
        public virtual ICollection<Review> Reviews { get; set; }

        public Destination()
        {
            this.Reviews = new HashSet<Review>();
        }
    }
}