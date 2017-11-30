using ClassLibrary.Model;
using Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using System.Web.WebPages.Html;

namespace WebApplication.Controllers
{
    public class LessonController : Controller
    {
        Context context = Storage.Context.GetInstance();

        // GET: Lesson
        public ActionResult Lesson(int courseId, int lessonId)
        {
            Lesson lesson = context.GetLessonById(lessonId);

            // Tilføjer en AbsenceRegistration til hver studerende til den valgt lektion, første gang underviseren åbner lektionen
            if(lesson.AbsenceRegistrations.Count == 0)
            {
                context.InitAbsenceRegistrationForLesson(lessonId, courseId);
            }

            AbsenceRegModel viewModel = new AbsenceRegModel() { Lesson = lesson, AbsenceRegistrations = lesson.AbsenceRegistrations, CourseId = courseId };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Lesson(AbsenceRegModel model)
        {
            context.AddAbsenceRegistrations(model.AbsenceRegistrations);

            // Sørger for at brugeren bliver på samme side
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}