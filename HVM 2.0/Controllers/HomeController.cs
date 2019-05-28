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
        private Entities db = new Entities();

        int r_codeVisit = -1;
        public ActionResult Index()
        {
            //Authentification Visiteur
            if (Request.HttpMethod == "POST")
            {
                if(Request.Form["codeVisiteur"] != null && Request.Form["codeVisiteur"] != "")
                {
                    r_codeVisit = Int32.Parse(Request.Form["codeVisiteur"]);
                    if (r_codeVisit.ToString() != null && r_codeVisit != -1)
                    {
                        foreach (var item in db.Utilisateur.ToList())
                        {
                            if (r_codeVisit == item.code_visiteur)
                            {
                                Session["codeVisiteur"] = r_codeVisit;
                                Session["idVisiteur"] = item.id_patient;
                                return RedirectToAction("Index", "Visiteurs");
                            }
                        }
                    }
                }
                
            } 

            //Authentification Patient
            if (Request.HttpMethod == "POST")
            {
                if (Request.Form["p_Patient"] != null)             
                {
                    foreach (var item in db.Utilisateur.ToList())
                    {
                        if (Request.Form["p_Patient"].ToString() == item.login.Trim() && Request.Form["pass"].ToString() == item.password.Trim())
                        {
                            Session["p_Patient"] = Request.Form["p_Patient"];

                            if (item.administrateur == false)
                                return RedirectToAction("Index", "Patients");
                            else
                                return RedirectToAction("Index", "Administrateurs");
                        }
                    }
                }
            }
            return View();
        }
    }
}