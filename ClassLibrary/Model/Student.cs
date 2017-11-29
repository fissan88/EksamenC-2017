using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            decimal countAbsence = 0;
            decimal totalRegistrations = 0;
            if(AbsenceRegistrations != null || AbsenceRegistrations.Count > 0)
            {
                foreach (var a in AbsenceRegistrations)
                {
                    if (a.AbsenceState != null && c.Lessons.Contains(a.Lesson))
                    {
                        totalRegistrations++;
                        if (a.AbsenceState == AbsenceRegistration.AbsenceStateTypes.Absent || a.AbsenceState == AbsenceRegistration.AbsenceStateTypes.LegalAbsence)
                        {
                            countAbsence++;
                        }
                    }
                }

                if (totalRegistrations != 0)
                {
                    decimal result = (countAbsence / totalRegistrations) * 100;
                    return Math.Round(result, 2); ;
                }

            }
            return 0;
        }
    }
}

