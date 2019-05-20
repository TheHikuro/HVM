﻿using System;
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
        private Database1Entities1 db = new Database1Entities1();
        Creneau creneau;
        Visiteur m_visiteur = new Visiteur();
        string tempCreneau;
        


        /*public ActionResult Index()
        {
            return View();
        }*/
        public ActionResult Index()
        {
            object test = Session["codeVisiteur"];
            List<Creneau> creneauTmpR = new List<Creneau>();
            //m_visiteur.codeVisit = id;
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
                   
                    creneauTmpR.Add(new Creneau(DateTime.Parse(newdate)));
                }
            }

            //Retire le creneau occupé
            foreach (Creneau crn in creneauTmpR)
            {
                foreach (Creneau dBcrn in db.Creneau)
                {
                    if (crn.date == dBcrn.date && crn.id_patient == dBcrn.id_patient)
                        creneauTmpR.Remove(crn);
                }
            }

            //récupération du submit depuis la view : Index 
            if (Request.HttpMethod == "POST")
            {
                if (Request.Form["Creneaux"] != null)
                {
                    tempCreneau = Request.Form["Creneaux"].ToString();

                    return RedirectToAction("Inscription", "Visiteurs", new { tempCreneau });
                }
            }
                return View(creneauTmpR);
        }

        
        public ActionResult Inscription(string tempCreneau)
        {
            object test = Session["codeVisiteur"];
            int idVisiteur = 1;

            if (Request.HttpMethod == "POST" && tempCreneau != null)
            {
                if (Request.Form["prenom"] != null && Request.Form["nom"] != null && Request.Form["mail"] != null)
                {
                    foreach(var item in db.Visiteur.ToList())
                    {
                        if (item.id_Visiteur > idVisiteur)
                            idVisiteur = item.id_Visiteur;
                    }
                    m_visiteur = new Visiteur(idVisiteur + 1,Request.Form["prenom"],Request.Form["nom"],Request.Form["mail"]);
                    db.Visiteur.Add(m_visiteur);
                    db.SaveChanges();
                    int j = 0;
                    foreach(var item in db.Creneau.ToList())
                    {
                        j++;
                    }
                    j++;

                    creneau = new Creneau(j,Convert.ToDateTime(tempCreneau), Int32.Parse(Session["idVisiteur"].ToString()));
                    
                    db.Creneau.Add(creneau);
                    db.SaveChanges();
                    
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        }
    }
    

