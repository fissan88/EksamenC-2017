using ClassLibrary.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ClassLibrary.Test
{
    public class CourseTest
    {
        [Fact]
        public void TestCalcAverageAbsenceRate_AllPresentShouldReturn0()
        {
            User[] users =
            {
                new Student { Username = "student1", FullName = "StudentTest1" },
                new Student { Username = "student2", FullName = "StudentTest2" }
            };

            var lesson1 =
                new Lesson(new DateTime(2017, 11, 26, 08, 30, 00), new DateTime(2017, 11, 26, 10, 00, 00));

            lesson1.AbsenceRegistrations.Add(new AbsenceRegistration { Student = (Student)users[0], AbsenceState = AbsenceRegistration.AbsenceStateTypes.Present });
            lesson1.AbsenceRegistrations.Add(new AbsenceRegistration { Student = (Student)users[1], AbsenceState = AbsenceRegistration.AbsenceStateTypes.Present });

            var course = new Course("Course1");

            course.Lessons.Add(lesson1);

            var result = course.CalcAverageAbsenceRate();
            Assert.Equal(0, result);
        }

        [Fact]
        public void TestCalcAverageAbsenceRate_NoLessonsInCourseShouldReturn0()
        {
            var course = new Course("Course1");

            var result = course.CalcAverageAbsenceRate();
            Assert.Equal(0, result);
        }

        [Fact]
        public void TestCalcAverageAbsenceRate_HalfOfStudentsAbsentShouldReturn500()
        {
            User[] users =
            {
                new Student { Username = "student1", FullName = "StudentTest1" },
                new Student { Username = "student2", FullName = "StudentTest2" }
            };

            var lesson1 =
                new Lesson(new DateTime(2017, 11, 26, 08, 30, 00), new DateTime(2017, 11, 26, 10, 00, 00));

            lesson1.AbsenceRegistrations.Add(new AbsenceRegistration { Student = (Student)users[0], AbsenceState = AbsenceRegistration.AbsenceStateTypes.Absent });
            lesson1.AbsenceRegistrations.Add(new AbsenceRegistration { Student = (Student)users[1], AbsenceState = AbsenceRegistration.AbsenceStateTypes.Present });

            var course = new Course("Course1");

            course.Lessons.Add(lesson1);

            var result = course.CalcAverageAbsenceRate();
            Assert.Equal(50, result);
        }

        [Fact]
        public void TestCalcAverageAbsenceRate_AllAbsentShouldReturn100()
        {
            User[] users =
            {
                new Student { Username = "student1", FullName = "StudentTest1" },
                new Student { Username = "student2", FullName = "StudentTest2" }
            };

            var lesson1 =
                new Lesson(new DateTime(2017, 11, 26, 08, 30, 00), new DateTime(2017, 11, 26, 10, 00, 00));

            lesson1.AbsenceRegistrations.Add(new AbsenceRegistration { Student = (Student)users[0], AbsenceState = AbsenceRegistration.AbsenceStateTypes.Absent });
            lesson1.AbsenceRegistrations.Add(new AbsenceRegistration { Student = (Student)users[1], AbsenceState = AbsenceRegistration.AbsenceStateTypes.Absent });

            var course = new Course("Course1");

            course.Lessons.Add(lesson1);

            var result = course.CalcAverageAbsenceRate();
            Assert.Equal(100, result);
        }
    }
}
