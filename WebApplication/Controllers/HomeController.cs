using Model;
using Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        Context context = new Context();

        public ActionResult Index(int? userId)
        {
            User user = context.getUserById(userId);
            if (user != null)
            {
                return View(user);
            }
            else return RedirectToAction("Index", "Login");
        }
    }
}
