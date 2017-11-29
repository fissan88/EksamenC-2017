using ClassLibrary.Model;
using Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class CourseController : Controller
    {
        Context context = Storage.Context.GetInstance();

        // GET: Course
        public ActionResult Course(int courseId)
        {
            Course course = context.GetCourseById(courseId);
            return View(course);
        }

        // GET: AbsencePerStudent
        public ActionResult AbsencePerStudent(int courseId)
        {
            Course course = context.GetCourseById(courseId);
            return View(course);
        }
    }
}