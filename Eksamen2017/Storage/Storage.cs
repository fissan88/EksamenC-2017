using Eksamen2017.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamen2017.Storage
{
    public class Storage : DbContext
    {
        public Storage() :base("name=Database") { }

        public DbSet<User> Users { get; set; }

        public User getUserByUserName(string userName)
        {
            User user = Users.FirstOrDefault(x => x.UserName == userName);
            return user;
        }
    }
}
