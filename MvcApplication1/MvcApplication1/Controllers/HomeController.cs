using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        AdminUslugi _admin = new AdminUslugi();
        KomentarzeUslugi _komentarz = new KomentarzeUslugi();

        public ActionResult Index()
        {
            //IEnumerable<post> dane = _admin.WyswietlPosty();
            //return View(dane);
            ViewData["Message"] = "Wellcome";
            ViewData["lista"] = _admin.WyswietlPosty();
            return View();
        }

        //public ActionResult wyswietlKomentarze(int i)
        //{
        //    //ViewData["list"] = _komentarz.WyswietlKomentarze(0);
        //    IEnumerable<komentarz> dane = _komentarz.WyswietlKomentarze(i);
        //    return View(dane);
        //}

        //[HttpPost]
        public ActionResult wyswietlKomentarze(int id)
        {
            try
            {
                //IEnumerable<komentarz> dane = _komentarz.WyswietlKomentarze();
                //return View(dane);
                ViewData["id"] = id;
                ViewData["post"] = _admin.WyswietlPostPoID(id);
                ViewData["lista"]= _komentarz.WyswietlKomentarze(id);
                return View();
            }
            catch
            {
                ViewData["alert"] = "cos nie teges";
                return View();
            }
        }

        public ActionResult dodajKomentarz()
        {
            return View();
        }

        [HttpPost]
        public ActionResult dodajKomentarz(int id, Komentarze k)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _komentarz.DodajKomentarz(id,k);
                    //ViewData["alert"] = "dodany";
                    return RedirectToAction("wyswietlKomentarze/"+id.ToString(), "Home");
                }
                else
                    return View();
            }
            catch
            {
                return RedirectToAction("Error", "Shared");
            }
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult WyswietlArchiwum(int id)
        {
            ViewData["archiwum"] = _admin.WyswietlPoDacie(id);
            return View();
        }

        public ActionResult WyswietlPostyPoTagach(string slowo)
        {
            ViewData["poTagach"] = _admin.WyswietlPoTagach(slowo);
            return View();
        }

    }
}
