using Microsoft.EntityFrameworkCore;

namespace Travel.Models
{
    public class TravelContext : DbContext
    {
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseMySql(@"server=localhost;user id=root;password=epicodus;port=3306;database=travel;");

        public TravelContext(DbContextOptions options) : base(options)
        {

        }
        public TravelContext()
        {

        }
    }
}