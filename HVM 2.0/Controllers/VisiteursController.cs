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


            TimeSpan time1 = new TimeSpan(2, 4, 18);
            TimeSpan time2 = new TimeSpan(3, 5, 19);
            TimeSpan time3 = new TimeSpan(4, 6, 20);

            DateTime date1 = DateTime.Now.ToLocalTime();
            DateTime date2 = new DateTime(2017, 5, 16);
            DateTime date3 = new DateTime(2018, 9, 25);

            
            creneauTmpR.Add(new Creneau { id_creneau = 1, heure = time1, date = date1 });
            creneauTmpR.Add(new Creneau { id_creneau = 2, heure = time2, date = date2 });
            creneauTmpR.Add(new Creneau { id_creneau = 3, heure = time3, date = date3 });

            //ViewData["Creneau"] = creneauTmpR;

            

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
    

