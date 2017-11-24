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
        Context context = new Context();

        // GET: Index
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string username)
        {
            User user = context.getUserByUsername(username);
            if (user != null)
            {
                return RedirectToAction("Index", "Home", new { userId = user.Id });
            }
            else return View();
        }
    }
}