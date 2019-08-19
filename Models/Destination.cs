using System;
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
        public double AvgRating { get; set; }
        // public int RatingSum { get; set; }
        
        public ICollection<Review> Reviews { get; set; }

        // public void UpdateRatingSum()
        // {

        // }

        public void GetAvgRating()
        {
            Console.WriteLine("Getting average rating");
            double sum = 0;
            foreach (Review review in Reviews)
            {
                sum += review.Rating;
                Console.WriteLine("Sum = " + sum);
                Console.WriteLine("Reviews list: " + Reviews.Count);
            }
            AvgRating = sum / Reviews.Count;
        }

        public Destination()
        {
            this.Reviews = new HashSet<Review>();
        }
    }
}