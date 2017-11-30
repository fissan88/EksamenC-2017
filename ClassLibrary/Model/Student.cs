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
            List<Course> Courses = new List<Course>();
            List<AbsenceRegistration> AbsenceRegistrations = new List<AbsenceRegistration>();
        }
       
        public List<AbsenceRegistration> AbsenceRegistrations { get; set; }
        public List<Course> Courses { get; set; }

        public decimal[] CalcAbsenceRate(Course c)
        {
            decimal countAbsence = 0;
            decimal countLegalAbsence = 0;
            decimal totalRegistrations = 0;
            decimal[] result = { 0, 0 };

            if(AbsenceRegistrations != null || AbsenceRegistrations.Count > 0)
            {
                foreach (var a in AbsenceRegistrations)
                {
                    if (a.AbsenceState != null && c.Lessons.Contains(a.Lesson))
                    {
                        totalRegistrations++;
                        if (a.AbsenceState == AbsenceRegistration.AbsenceStateTypes.Absent)
                        {
                            countAbsence++;
                        }

                        if (a.AbsenceState == AbsenceRegistration.AbsenceStateTypes.LegalAbsence)
                        {
                            countLegalAbsence++;
                        }
                    }
                }

                if (totalRegistrations != 0)
                {
                    decimal resultCountAbsence = (countAbsence / totalRegistrations) * 100;
                    decimal resultCountLegalAbsence = (countLegalAbsence / totalRegistrations) * 100;
                    result[0] = Math.Round(resultCountAbsence, 2);
                    result[1] = Math.Round(resultCountLegalAbsence, 2);
                    return result;
                }
            }
            return result;
        }
    }
}

