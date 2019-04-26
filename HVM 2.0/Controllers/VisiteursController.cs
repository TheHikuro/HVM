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

        // GET: Visiteurs
        public ActionResult Index()
        {
             IList<Creneau> creneauTmpR = new List<Creneau>();

            for (int i = 1; i < 15; i++)
            {
                creneauTmpR.Add(new Creneau { date = DateTime.Now.AddDays(i) });
            }

            for(int h = 6; h < 18; h++)
            {
                //creneauTmpR.Add(new Creneau { heure = DateTime.Now.AddHours(h) });
            }

            foreach(Creneau crn in creneauTmpR)
            {
                foreach(Creneau dBcrn in db.Creneau)
                {
                    if (crn.id_creneau == dBcrn.id_creneau && crn.id_patient == dBcrn.id_patient)
                        creneauTmpR.Remove(crn);
                }
            }
                return View(creneauTmpR);
        }


    
        }
    }
    

