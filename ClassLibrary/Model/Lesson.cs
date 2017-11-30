using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClassLibrary.Model.AbsenceRegistration;

namespace ClassLibrary.Model
{
    public class Lesson
    {
        public Lesson()
        {

        }

        public Lesson(DateTime startDate, DateTime endDate)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Visisted = false;
            this.AbsenceRegistrations = new List<AbsenceRegistration>();
        }

        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Visisted { get; set; }
        public List<AbsenceRegistration> AbsenceRegistrations { get; set; }

        // Tjekker hvor vidt lekionen er gyldig til fraværsregistrering. Returnerer true hvis lektionens slutdato er dagsdato eller ældre.
        public bool IsValidForRegistration()
        {
            DateTime now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            return this.EndDate.CompareTo(now) >= 0;
        }
    }
}
