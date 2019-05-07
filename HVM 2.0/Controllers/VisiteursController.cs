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
    public class VisiteursController : Controller
    {
        private Database1Entities db = new Database1Entities();
        Creneau creneau = new Creneau();
        Visiteur m_visiteur = new Visiteur();
        List<String> tempCreneau = new List<String>();

        public ActionResult Index()
        {
            List<Creneau> creneauTmpR = new List<Creneau>();

            for (int i = 1; i < 15; i++)
            {
                //creneauTmpR.Add(new Creneau { date = DateTime.Now.AddDays(i) });
                string date = DateTime.Now.AddDays(i).ToString();
                string newdate = null;
                date = date.Substring(0, 10);
                for(int h = 7; h < 18; h++)
                {
                    if (h < 10)
                    {
                        newdate = date + " " + 0 + h + ":00:00";
                    }
                    
                    else
                    {
                        newdate = date + " " + h + ":00:00";
                    }
                   
                    creneauTmpR.Add(new Creneau(DateTime.Parse(newdate)) );
                }
            }

            //récupération du submit depuis la view : Index 
            if (Request.HttpMethod == "POST")
            {
                if (Request.Form["Creneaux"] != null)
                {
                    tempCreneau.Add(Request.Form["Creneaux"]);
                    
                    return RedirectToAction("Inscription", "Visiteurs");
                }
            }

            //Retire le creneau occupé
            foreach (Creneau crn in creneauTmpR)
            {
                foreach(Creneau dBcrn in db.Creneau)
                {
                    if (crn.id_creneau == dBcrn.id_creneau && crn.id_patient == dBcrn.id_patient)
                        creneauTmpR.Remove(crn);
                }
            }
                return View(creneauTmpR);
            
        }

        [HttpPost]
        public ActionResult Inscription()
        {
            if (Request.HttpMethod == "POST")
            {
                if (Request.Form["creneauxOccup"] != null)
                {
                    db.Visiteur.Add(m_visiteur);
                    //db.Creneau.Add(listTampon);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        }
    }
    

