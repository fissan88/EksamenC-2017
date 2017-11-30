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
    public class LoginController : Controller
    {
        Context context = Storage.Context.GetInstance();

        // GET: Index
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username)
        {
            User user = context.GetUserByUsername(username);
            if (user != null)
            {
                if(IsUserTeacher(user))
                {
                    return RedirectToAction("Index", "Teacher", new { teacherId = user.Id });
                }
                else
                {
                    return RedirectToAction("Index", "Student", new { studentId = user.Id });
                }
            }
            else return View();
        }

        public bool IsUserTeacher(User u)
        {
            return u.GetType() == typeof(Teacher);
        }
    }
}