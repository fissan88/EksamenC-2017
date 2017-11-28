using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Model
{
    public class AbsenceRegistration
    {
        public enum AbsenceStateTypes { Present, Absent, [Description("Legal Absence")] LegalAbsence }

        public AbsenceRegistration()
        {

        }

        public AbsenceRegistration(Student student, Lesson lesson)
        {
            this.Student = student;
            this.Lesson = lesson;
        }

        public int Id { get; set; }
        public Student Student { get; set; }
        public Lesson Lesson { get; set; }
        public AbsenceStateTypes AbsenceState { get; set; }
    }
}
