using Model;
using Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class StudentController : Controller
    {
        Context context = Storage.Context.GetInstance();

        // GET: Student
        public ActionResult Index(int id)
        {
            User user = context.GetUserById(id);
            if (user != null)
            {
                return View(user);
            }
            else return RedirectToAction("Login", "Login");
        }
    }
}