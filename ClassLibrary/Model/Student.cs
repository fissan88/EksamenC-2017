using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Model
{
    public class Student : User
    {
        public Student()
        {

        }

        public List<AbsenceRegistration> AbsenceRegistrations { get; set; }
        public List<Course> Courses { get; set; }

       public decimal CalcAbsenceRate(Course c)
       {
           return 0;
       }
       
        public decimal CalcAbsenceRateTotal()
        {
            return 0;
        }
    }
}
