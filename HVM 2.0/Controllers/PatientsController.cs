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
        private Database1Entities db = new Database1Entities();

        // GET: Patients
        public ActionResult Index()
        {
            Creneau creneau = new Creneau();
            return View(db.Creneau);
        }

    }

}