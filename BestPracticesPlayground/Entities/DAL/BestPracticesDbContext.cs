using Entities;
using System.Data.Entity;

namespace BestPracticesPlayground.Entities
{
    public class BestPracticesDbContext : DbContext
    {
        public BestPracticesDbContext() : base("BestPracticesDB")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<BestPracticesDbContext, Configuration>());
            Database.SetInitializer(new DropCreateDatabaseAlways<BestPracticesDbContext>());
        }


        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<MailingList> MailingLists { get; set; }

        public DbSet<AuthorizationLevel> AuthorizationLevels { get; set; }

    }
}
