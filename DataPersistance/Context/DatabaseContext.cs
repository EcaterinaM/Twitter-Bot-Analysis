using DataDomain.DataModel;
using Microsoft.EntityFrameworkCore;

namespace DataPersistance.Context
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) 
            :base(options)
        {
        }

        public DbSet<Tweet> TweetModel { get; set; }

        public DbSet<UserInformation> UserInformation { get; set; }

        public DbSet<HashtagHistory> HashtagHistoryModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserInformation>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<HashtagHistory>()
                .HasOne(t => t.TweetModel);

        }
    }
}
