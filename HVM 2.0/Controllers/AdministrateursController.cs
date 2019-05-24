using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HVM_2._0.Models;
using System.Net.Mail;

namespace HVM_2._0.Controllers
{
    public class AdministrateursController : Controller
    {
        private Database1Entities1 db = new Database1Entities1();

        public ActionResult Index()
        {
            int idUser = 1;
            bool admin = false;

            if (Request.HttpMethod == "POST")
            {
                foreach (var item in db.Utilisateur.ToList())
                { idUser++; }

                if (Request.Form["admin"] != null)
                {
                    if(Request.Form["admin"].ToString() == "Yes")
                        admin = true;
                }

                db.Utilisateur.Add(new Utilisateur(idUser, Request.Form["prenom"].ToString(),
                    Request.Form["nom"].ToString(), Int32.Parse(Request.Form["age"].ToString()),
                    Request.Form["login"].ToString(), Request.Form["password"].ToString(), 
                    Int32.Parse(Request.Form["codeV"].ToString()), admin));
            }
            db.SaveChanges();
            return View();
        }
    }
}