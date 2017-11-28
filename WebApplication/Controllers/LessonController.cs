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
        public ActionResult Lesson(int teacherId, int courseId, int lessonId)
        {
            Lesson lesson = context.GetLessonById(lessonId);
            List<Student> students = context.GetCourseById(courseId).Students;

            if(lesson.AbsenceRegistrations.Count == 0)
            {
                for(int i = 0; i < students.Count; i++)
                {
                    context.AddAbsenceRegistration(lesson, students[i]);
                }
            }

            AbsenceRegModel viewModel = new AbsenceRegModel() { Lesson = lesson, Students = students, AbsenceRegistrations = lesson.AbsenceRegistrations, CourseId = courseId, TeacherId = teacherId };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Lesson(AbsenceRegModel model)
        {
            foreach(var a in model.AbsenceRegistrations)
            {
                context.GetAbsenceRegistrationById(a.Id).AbsenceState = a.AbsenceState;
            }

            context.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}