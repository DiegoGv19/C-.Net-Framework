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


        public ActionResult Tabla(int? i, string sortBy)
        {
            if (!ModelState.IsValid)
            {
                List<Graduates_From_University> vacio = new List<Graduates_From_University>();
                return View(vacio);
            }

            try
            {
                ViewBag.SortYearParameter = sortBy == "Year" ? "Year desc" : "Year";
                ViewBag.SortTypeParameter = sortBy == "Type" ? "Type desc" : "Type";

                ViewBag.SortSexParameter = sortBy == "Sex" ? "Sex desc" : "Sex";
                ViewBag.SortNumeroParameter = sortBy == "Numero" ? "Numero desc" : "Numero";


                DataGovSgEntities db = new DataGovSgEntities();


                var lista = db.Graduates_From_University.AsQueryable();

                switch (sortBy)
                {
                    case "Year":
                        lista = lista.OrderByDescending(x => x.Year);
                        break;
                    case "Type":
                        lista = lista.OrderByDescending(x => x.TypeOfCourse);
                        break;
                    case "Sex":
                        lista = lista.OrderByDescending(x => x.Sex);
                        break;
                    case "Numero":
                        lista = lista.OrderByDescending(x => x.NoOfGraduates);
                        break;
                    default:
                        lista = lista;
                        break;

                }

                return View(lista.ToList().ToPagedList(i ?? 1,6));
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
