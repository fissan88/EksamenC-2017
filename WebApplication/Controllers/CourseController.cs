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
        public ActionResult Course(int courseId, int teacherId)
        {
            Course course = context.GetCourseById(courseId);
            return View(course);
        }
    }
}