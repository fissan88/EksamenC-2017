namespace Eksamen2017.Migrations
{
    using Eksamen2017.Model;
    using Eksamen2017.Storage;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Storage>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Storage context)
        {
            context.Users.AddOrUpdate(user => user.Id,
                new User { UserName = "user1" },
                new User { UserName = "user2" }
            );

            context.SaveChanges();
        }
    }
}
