using assignment2_validation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace assignment2_validation.Controllers
{
    public class FormController : Controller
    {
        // GET: Form
        [HttpGet]
        public ActionResult Registration()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Registration(FormData form)
        {
            
            if (ModelState.IsValid)
            {
                TempData["name"] = form.name;
                TempData["id"] = form.id;
                TempData["gender"] = form.gender;
                TempData["email"] = form.email;
                TempData["dob"] = form.dob;

                return RedirectToAction("FormView");
            }

            return View(form);
        }

        public ActionResult FormView()
        {
            return View();
        }

    }
}