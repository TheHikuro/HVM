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
            CreneauLibre creneauLibre = new CreneauLibre();


            for (int i = 1; i < 15; i++)
            {
                creneauTmpR.Add(new Creneau { date = DateTime.Now.AddDays(i) });
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


            class CreneauLibre
            {
                DateTime start;
                Random gen;
                int range;

                public CreneauLibre()
                {
                    start = new DateTime(1995, 1, 1);
                    gen = new Random();
                    range = (DateTime.Today - start).Days;
                }

                public DateTime Next()
                {
                    return start.AddDays(gen.Next(range)).AddHours(gen.Next(0, 24)).AddMinutes(gen.Next(0, 60)).AddSeconds(gen.Next(0, 60));
                }
            }
    
        }
    }
    

