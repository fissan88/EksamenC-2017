using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using static ClassLibrary.Model.AbsenceRegistration;
using System.ComponentModel;

namespace ClassLibrary.Model
{
    public class Teacher : User
    {
        public Teacher()
        {
            Courses = new List<Course>();
        }

        public List<Course> Courses { get; set; }
    }
}
