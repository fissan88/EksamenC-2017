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
        public enum BlockType {
            [Description("8.30 - 10.00")] b1,
            [Description("10.30 - 12.00")] b2,
            [Description("12.30 - 14.00")] b3
        }

        public Lesson()
        {

        }

        public int Id { get; set; }
        public BlockType Block { get; set; }
        public DateTime Date { get; set; }
        public List<AbsenceRegistration> AbsenceRegistrations { get; set; }

        // Tjekker hvor vidt lekionen er gyldig til fraværsregistrering. Returnerer true hvis lektionens dato er dagsdato eller ældre.
        public bool IsValidForRegistration()
        {
            DateTime now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            return this.Date.CompareTo(now) >= 0;
        }
    }
}
