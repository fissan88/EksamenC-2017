namespace Eksamen2017.Migrations
{
    using Storage;
    using Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Context context)
        {
            context.Users.AddOrUpdate(user => user.Username,
                new User { Username = "user1" },
                new User { Username = "user2" }
            );

            context.SaveChanges();
        }
    }
}
