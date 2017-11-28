
using ClassLibrary.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClassLibrary.Model.AbsenceRegistration;

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
            User user = Users.FirstOrDefault(u => u.Username == username);
            return user;
        }

        public Teacher GetTeacherById(int? id)
        {
            Teacher teacher = Users.OfType<Teacher>().Include(t => t.Courses).FirstOrDefault(u => u.Id == id);
            return teacher;
        }

        public User GetUserById(int? id)
        {
            User user = Users.FirstOrDefault(u => u.Id == id);
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
            Course course = Courses.Include(x => x.Lessons).Include(x => x.Students).FirstOrDefault(x => x.Id == id);
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

        public Lesson GetLessonById(int? id)
        {
            Lesson lesson = Lessons.Include(l => l.AbsenceRegistrations).FirstOrDefault(l => l.Id == id);
            return lesson;
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

        public List<Course> GetCoursesStudentNotEnrolledIn(Student s)
        {
            return Courses.Where(c => !c.Students.Select(student => student.Id).Contains(s.Id)).ToList();
        }

        public List<Course> GetCoursesOfTeacher(Teacher t)
        {
            return Courses.Include(c => c.Lessons).Where(c => c.Teacher.Id == t.Id).ToList();
        }

        public void AddAbsenceRegistration(Lesson l, Student s)
        {
            AbsenceRegistrations.Add(new AbsenceRegistration(s, l));
            SaveChanges();
        }

        public AbsenceRegistration GetAbsenceRegistrationById(int? id)
        {
            AbsenceRegistration absenceRegistration = AbsenceRegistrations.FirstOrDefault(a => a.Id == id);
            return absenceRegistration;
        }

    }
}
