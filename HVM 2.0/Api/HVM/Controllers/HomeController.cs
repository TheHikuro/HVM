using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HVM.Models;

namespace HVM.Controllers
{
    public class HomeController : Controller
    {
        private Database1Entities1 db = new Database1Entities1();

        public ActionResult Index()
        {
            System.Console.WriteLine("index loading ");
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        { 
            return View();
        }

        public int Authentification(String p_Login, String p_password)
        {
            // 0 = Erreur lors de la récupération ; 1 = User reconnu ; 2 = Mot de passe ou login incorrect
            
            foreach (Patient usr in db.Patient)
            {
                if (p_Login == usr.login && p_password == usr.password)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            return 0;
        }

        public ActionResult AddToCart(string id)
        {
            string newId = id;
            // return Json(newId, JsonRequestBehavior.AllowGet);
            var script = @"alert(""Email sent successfully"");";
            return JavaScript(script);
        }
    }
}