
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
        public static Context instance;

        public static Context GetInstance()
        {
            if(instance == null)
            {
                instance = new Context();
                
            }
            return instance;
        }

        public Context() :base("name=Database") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<AbsenceRegistration> AbsenceRegistrations { get; set; }

        public User GetUserByUsername(string username)
        {
            User user = Users.FirstOrDefault(x => x.Username == username);
            return user;
        }

        public User GetUserById(int? id)
        {
            User user = Users.FirstOrDefault(x => x.Id == id);
            return user;
        }

        public void AddCourse(Course c)
        {
            Courses.Add(c);
            SaveChanges();
        }

        public List<Course> GetAllCourses()
        {
            return Courses.Include(c => c.Lessons).Include(c => c.Teacher).ToList();
        }

        public Course GetCourseById(int id)
        {
            Course course = Courses.Include(x => x.Lessons).FirstOrDefault(x => x.Id == id);
            return course;
        }

        public List<Teacher> GetAllTeachers()
        {
            return Users.OfType<Teacher>().ToList();
        }

        public List<Teacher> GetAllTeachersIncludingCourses()
        {
            return Users.OfType<Teacher>().Include(t => t.Courses).ToList();
        }

        public void AddTeacher(Teacher t)
        {
            Users.Add(t);
            SaveChanges();
        }

        public void AddLesson(Course c, Lesson l)
        {
            Lessons.Add(l);
            c.Lessons.Add(l);
            SaveChanges();
        }

        public List<Student> GetAllStudentsIncludingCourses()
        {
            return Users.OfType<Student>().Include(t => t.Courses).ToList();
        }

        public void AddStudent(Student s)
        {
            Users.Add(s);
            SaveChanges();
        }

        public void EnrollStudent(Course c, Student s)
        {
            s.Courses.Add(c);
            SaveChanges();
        }

        public void DeleteEnrollmentStudent(Course c, Student s)
        {
            s.Courses.Remove(c);
            SaveChanges();
        }
    }
}
