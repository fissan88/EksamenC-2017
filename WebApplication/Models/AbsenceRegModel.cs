using ClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc.Html;

namespace WebApplication.Models
{
    public class AbsenceRegModel
    {
        
        public AbsenceRegModel()
        {

        }
        public Lesson Lesson { get; set; }
        public List<AbsenceRegistration> AbsenceRegistrations { get; set; }
        public int CourseId { get; set; }
    }
}