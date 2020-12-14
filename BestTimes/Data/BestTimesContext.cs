using Microsoft.EntityFrameworkCore;

namespace BestTimes.Data
{
    public class BestTimesContext : DbContext
    {
        public DbSet<BestTime> BestTimes { get; set; }

        public BestTimesContext() { }
        public BestTimesContext(DbContextOptions<BestTimesContext> options)
            : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseSqlServer("Server=TESKERAS;Database=bestTimes;Trusted_Connection=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BestTime>().ToTable("bestTimes","dbo").HasKey(c => c.Id);
        }
    }
}
