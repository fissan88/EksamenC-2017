using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Model
{
    public class Course
    {
        public Course()
        {

        }

        public Course(string name, Teacher teacher)
        {
            this.Name = name;
            this.Teacher = teacher;
            this.Lessons = new List<Lesson>();
            this.Students = new List<Student>();
        }

        public int Id { get; set; }
        
        public string Name { get; set; }
        public List<Lesson> Lessons { get; set; }
        public List<Student> Students { get; set; }
        public Teacher Teacher { get; set; }
    }
}
