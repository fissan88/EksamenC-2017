namespace Eksamen2017.Migrations
{
    using Storage;
    using Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ClassLibrary.Model;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Context context)
        {
            User[] users =
            {
                new Teacher { Id = 1, Username = "teacher1", FullName = "TeacherTest" },     // 0, Teacher
                new Student { Id = 2, Username = "student1", FullName = "StudentTest1" },    // 1, Student
                new Student { Id = 3, Username = "student2", FullName = "StudentTest2" }     // 2, Student
            };

            context.Users.AddOrUpdate(u => u.Id,
                users
            );

            Lesson[] lessons =
            {
                new Lesson { Id = 1, StartDate = new DateTime(2017, 11, 26, 08, 30, 00), EndDate = new DateTime(2017, 11, 26, 10, 00, 00)},
                new Lesson { Id = 2, StartDate = new DateTime(2017, 11, 26, 10, 30, 00), EndDate = new DateTime(2017, 11, 26, 12, 00, 00)},
                new Lesson { Id = 3, StartDate = new DateTime(2017, 11, 26, 12, 30, 00), EndDate = new DateTime(2017, 11, 26, 14, 00, 00)}
            };

            context.Lessons.AddOrUpdate(l => l.Id, lessons);

            context.Courses.AddOrUpdate(c => c.Id,
                new Course {
                    Id = 1,
                    Name = "Course1",
                    Teacher = (Teacher) users[0],
                    Students = new List<Student> { (Student)users[1], (Student)users[2] },
                    Lessons = lessons.ToList()
                }       
            );

            context.AbsenceRegistrations.AddOrUpdate(a => a.Id,
                new AbsenceRegistration { Id = 1, Student = (Student) users[1], AbsenceState = AbsenceRegistration.AbsenceStateTypes.Present,Lesson = lessons[0] },
                new AbsenceRegistration { Id = 2, Student = (Student) users[1], AbsenceState = AbsenceRegistration.AbsenceStateTypes.Present,Lesson = lessons[1] },
                new AbsenceRegistration { Id = 3, Student = (Student) users[1], AbsenceState = AbsenceRegistration.AbsenceStateTypes.Absent, Lesson = lessons[2] }
            );

            context.SaveChanges();
        }
    }
}
