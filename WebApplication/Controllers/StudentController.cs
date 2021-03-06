﻿using ClassLibrary.Model;
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
        public ActionResult Index(int? studentId)
        {
            Student student = context.GetStudentById(studentId);
            if (student != null)
            {
                return View(student);
            }
            else return RedirectToAction("Login", "Login");
        }
    }
}