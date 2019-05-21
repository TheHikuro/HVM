using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HVM_2._0.Models;

namespace HVM_2._0.Controllers
{
    public class PatientsController : Controller
    {
        private Database1Entities1 db = new Database1Entities1();
        string confirmCreneaux;
        Creneau creneau = new Creneau();

        // GET: Patients
        public ActionResult Index()
        {
            if (Request.HttpMethod == "POST")
            {
                if (Request.Form["CreneauxPris"] != null)
                {
                   if(Request.Form["accept"] != null)
                    {
                        confirmCreneaux = Request.Form["CreneauxPris"];
                        return RedirectToAction("Mail", "Patients", new { confirmCreneaux });
                    }

                   if(Request.Form["refus"] != null)
                   {
                        confirmCreneaux = Request.Form["CreneauxPris"];
                        if (confirmCreneaux == creneau.date.ToString())
                        {
                            
                        }
                    }
                }
            }
            return View(db.Creneau);
        }

        public ActionResult Mail(string confirmCreneaux)
        {

            return View();
        }
            
    }

    

}