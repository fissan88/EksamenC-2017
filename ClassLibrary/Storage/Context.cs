
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public class Context : DbContext
    {
        public Context() :base("name=Database") { }

        public DbSet<User> Users { get; set; }

        // TEST

        public User getUserByUsername(string username)
        {
            User user = Users.FirstOrDefault(x => x.Username == username);
            return user;
        }

        public User getUserById(int? userId)
        {
            User user = Users.FirstOrDefault(x => x.Id == userId);
            return user;
        }
    }
}
