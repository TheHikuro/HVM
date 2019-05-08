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
    public class HomeController : Controller
    {
        private Database1Entities db = new Database1Entities();
        

        public ActionResult Index()
        {
            //Authentification Visiteur
            /*if (Request.HttpMethod == "POST")
            {
                if (Request.Form["codeVisiteur"] != "")
                {
                    foreach (var item in db.Patient.ToList())
                    {
                        if (Int32.Parse(Request.Form["codeVisiteur"]) == item.code_visiteur)
                        {
                            return RedirectToAction("Index", "Visiteurs");
                        }
                    }
                }
            } */

            //Authentification Patient
            if (Request.HttpMethod == "POST")
            {
                if (Request.Form["p_Patient"] != null)
                {
                    //foreach (var item in db.Patient.ToList())
                    //{
                        if (Request.Form["p_Patient"] == "e.lemee" && Request.Form["pass"] == "singe")
                        {
                            return RedirectToAction("Index", "Patients");
                        }
                    //}
                }
            }
            return View();
        }



    }
}