using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class AdminController : Controller
    {
        AdminUslugi db_admin = new AdminUslugi();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult dodajPost()
        {
            return View();
        }

        [HttpPost]
        public ActionResult dodajPost(Klasa k)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db_admin.DodajPost(k);
                    return RedirectToAction("Index", "Home");
                }
                else
                    return View();
            }
            catch
            {
                return RedirectToAction("Error", "Shared");
            }
        }

        public ActionResult edytujPost(int id)
        {
            //ViewData["id"] = id;
            post k = db_admin.EdytujPost(id);
            if (k == null)
                return RedirectToAction("Error", "Shared");
            else
                return View(k);
        }

        [HttpPost]
        public ActionResult edytujPost(post k)
        {
            try
            {
                //ViewData["id"] = id;
                db_admin.EdytujPost(k);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return RedirectToAction("Error", "Shared");
            }
        }
    }
}
