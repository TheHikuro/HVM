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

        // GET: Visiteurs
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult list()
        {
            return View();
        }
        public class ListCreneau : DropCreateDatabaseAlways<Database1Entities>
        {
            protected override void Seed(Database1Entities context)
            {
                TimeSpan time1 = new TimeSpan(2, 4, 18);
                TimeSpan time2 = new TimeSpan(3, 5, 19);
                TimeSpan time3 = new TimeSpan(4, 6, 20);

                DateTime date1 = new DateTime(2016, 6, 12);
                DateTime date2 = new DateTime(2017, 5, 16);
                DateTime date3 = new DateTime(2018, 9, 25);
                context.Creneau.Add(new Creneau { id_creneau = 1, heure = time1, date = date1 });
                context.Creneau.Add(new Creneau { id_creneau = 2, heure = time2, date = date2 });
                context.Creneau.Add(new Creneau { id_creneau = 3, heure = time3, date = date3 });

                base.Seed(context);
            }
        }
    }



}
