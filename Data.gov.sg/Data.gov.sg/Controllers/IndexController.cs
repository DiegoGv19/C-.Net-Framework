using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.gov.sg.Models;

namespace Data.gov.sg.Controllers
{
    public class IndexController : Controller
    {


        public ActionResult Tabla()
        {

            DataGovSgEntities db = new DataGovSgEntities();

            List<Graduates_From_University> lista = db.Graduates_From_University.ToList();
            return View(lista);
        }

    }
}
