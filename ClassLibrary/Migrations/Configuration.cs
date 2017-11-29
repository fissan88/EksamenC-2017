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
                new Student { Id = 2, Username = "student1", FullName = "StudentTest1" },
                new Student { Id = 3, Username = "student2", FullName = "StudentTest2" }  
            };

            Lesson[] lessons =
            {
                new Lesson { Id = 1, StartDate = new DateTime(2017, 11, 26, 08, 30, 00), EndDate = new DateTime(2017, 11, 26, 10, 00, 00)},
                new Lesson { Id = 2, StartDate = new DateTime(2017, 11, 26, 10, 30, 00), EndDate = new DateTime(2017, 11, 26, 12, 00, 00)},
                new Lesson { Id = 3, StartDate = new DateTime(2017, 11, 26, 12, 30, 00), EndDate = new DateTime(2017, 11, 26, 14, 00, 00)}
            };

            context.Users.AddOrUpdate(u => u.Id, users[0], users[1]);

            Course[] courses = 
            {
                new Course
                    {
                        Id = 1,
                        Name = "Course1",
                        Students = new List<Student> { (Student)users[0], (Student)users[1] },
                        Lessons = lessons.ToList()
                    }
            };

            Teacher teacher = new Teacher { Id = 1, Username = "teacher1", FullName = "TeacherTest", Courses = courses.ToList() };

            context.Users.AddOrUpdate(u => u.Id, teacher);

            context.Lessons.AddOrUpdate(l => l.Id, lessons);

            context.Courses.AddOrUpdate(c => c.Id,
                  courses    
            );

            context.SaveChanges();
        }
    }
}
