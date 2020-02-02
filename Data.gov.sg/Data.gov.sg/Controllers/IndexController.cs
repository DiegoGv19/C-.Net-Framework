using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.gov.sg.Models;
using PagedList.Mvc;
using PagedList;

namespace Data.gov.sg.Controllers
{
    public class IndexController : Controller
    {


        public ActionResult Tabla(int? i)
        {
            if (!ModelState.IsValid)
            {
                List<Graduates_From_University> vacio = new List<Graduates_From_University>();
                return View(vacio);
            }

            try
            {
                DataGovSgEntities db = new DataGovSgEntities();

                List<Graduates_From_University> lista = db.Graduates_From_University.ToList();
                return View(lista.ToPagedList(i ?? 1,6));
            }
            catch(Exception e)
            {
                ModelState.AddModelError("", "Error: " + e.Message);
                List<Graduates_From_University> vacio = new List<Graduates_From_University>();
                return View(vacio);
            }
            
        }

    }
}
