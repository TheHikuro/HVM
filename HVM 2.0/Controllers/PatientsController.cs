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
    public class PatientsController : Controller
    {
        private Database1Entities1 db = new Database1Entities1();
        string confirmCreneaux;
        Creneau creneau = new Creneau();
        Patient patient = new Patient();
        

        // GET: Patients
        public ActionResult Index()
        {
            object sess = Session["p_Patient"];
            if (Request.HttpMethod == "POST")
            {
                if (Request.Form["CreneauxPris"] != null)
                {
                   if(Request.Form["accept"] != null)
                    {
                        confirmCreneaux = Request.Form["CreneauxPris"];
                        return RedirectToAction("Mail", "Patients", new { confirmCreneaux });
                    }

                   if(Request.Form["refus"] != null)
                   {
                        confirmCreneaux = Request.Form["CreneauxPris"];
                        foreach(var item in db.Creneau)
                        {
                            if (confirmCreneaux == item.date.ToString())
                            {
                                db.Creneau.Remove(item);
                                
                            }
                        }
                    }
                }
            }
            all All = new all();
            All.crenaux = db.Creneau.ToList();
            All.patients = db.Patient.ToList();
            db.SaveChanges();
            return View(All);
        }

        public ActionResult Mail(string confirmCreneaux)
        {
            
            var fromAdress = new MailAddress("Hopital.Manager@gmail.com", "HVM");
            var toAddress = new MailAddress("loan.cleris@gmail.com");
            const string fromPassword = "HVM2019'";
            string subject = "Reponse à votre demande de visite";
            

            var SmtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential(fromAdress.Address, fromPassword)
            };

            object sess = Session["p_Patient"];
            if (Request.HttpMethod == "POST")
            {
                if (Request.Form["sendMailConf"] != null)
                {
                    string bodyAccept = "Ceci est un message automatique envoyé par l'application HVM /n /n" +
                "Bonjour, /n" + "" ;

                    using (var message = new MailMessage { Subject = subject, Body = bodyAccept })
                    {
                        SmtpClient.Send(message);
                    }
                }

            }

            return View();
        }
            
    }

    

}