using ClassLibrary.Model;
using Model;
using Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class TeacherController : Controller
    {
        Context context = Storage.Context.GetInstance();

        public ActionResult Index(int? id)
        {
            Teacher teacher = context.GetTeacherById(id);
            if (teacher != null)
            {
                return View(teacher);
            }
            else return RedirectToAction("Login", "Login");
        }
    }
}
