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

        public Course(string name)
        {
            this.Name = name;
            this.Lessons = new List<Lesson>();
            this.Students = new List<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Lesson> Lessons { get; set; }
        public List<Student> Students { get; set; }
        // public Teacher Teacher { get; set; }

        public override string ToString()
        {
            return Name;
        }
        
        public decimal CalcAverageAbsenceRate()
        {
            decimal countAbsence = 0;
            decimal totalRegistrations = 0;
            
            if (Lessons != null && Lessons.Count > 0)
            {
                foreach (var l in Lessons)
                {
                    foreach (var a in l.AbsenceRegistrations)
                    {
                        if (a.AbsenceState != null)
                        {
                            totalRegistrations++;
                            if (a.AbsenceState == AbsenceRegistration.AbsenceStateTypes.Absent || a.AbsenceState == AbsenceRegistration.AbsenceStateTypes.LegalAbsence)
                            {
                                countAbsence++;
                            }
                        }
                    }
                }
            }
            
            if(totalRegistrations != 0)
            {
                decimal result = (countAbsence / totalRegistrations) * 100;
                return Math.Round(result, 2); ;
            }
            else
            {
                return 0;
            }
        }
    }
}
