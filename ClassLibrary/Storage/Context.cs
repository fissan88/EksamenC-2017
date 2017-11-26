
using ClassLibrary.Model;
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
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<AbsenceRegistration> AbsenceRegistrations { get; set; }

        public User GetUserByUsername(string username)
        {
            User user = Users.FirstOrDefault(x => x.Username == username);
            return user;
        }

        public User GetUserById(int? userId)
        {
            User user = Users.FirstOrDefault(x => x.Id == userId);
            return user;
        }

        public List<Course> GetAllCourses()
        {
            return Courses.Include(c => c.Lessons).Include(c => c.Teacher).ToList();
        }

        public List<Teacher> GetAllTeachers()
        {
            return Teachers.ToList();
        }
    }
}
