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
        int idCreneau;
        // GET: Patients

        public ActionResult Index()
        {
            object sess = Session["p_Patient"];
            int idPatient = 0;

            foreach (var usr in db.Patient)
            {
                if (Session["p_Patient"].ToString() == usr.login.Trim())
                {
                    idPatient = usr.id_patient;
                }
            }

            if (Request.HttpMethod == "POST")
            {
                if (Request.Form["CreneauxPris"] != null)
                {
                   if(Request.Form["accept"] != null)
                   {
                        foreach (var item in db.Creneau)
                        {
                            if (item.date.ToString().Trim() == Request.Form["CreneauxPris"].Split('|')[0].Trim() && item.id_patient == idPatient)
                            {
                                item.disponibilite = false;
                                item.reserve = false;
                                idCreneau = item.id_creneau;
                            }
                        }
                        db.SaveChanges();
                        return RedirectToAction("Mail", "Patients");
                   }

                   if(Request.Form["refus"] != null)
                   {
                        foreach (var item in db.Creneau)
                        {
                            if (Request.Form["CreneauxPris"].Split('|')[0].Trim() == item.date.ToString().Trim() && idPatient == item.id_patient)
                            {
                                item.reserve = false;
                                //db.Creneau.Remove(item);
                            }
                        }
                   }
                }
            }

            all All = new all();
            All.crenaux = db.Creneau.ToList();
            All.patients = db.Patient.ToList();
            All.reserves = db.Reserve.ToList();
            All.visiteurs = db.Visiteur.ToList();
            db.SaveChanges();
            return View(All);
        }

        public ActionResult Mail()
        {
            var fromAdress = new MailAddress("Hopital.Manager@gmail.com", "HVM");
            var toAddress = new MailAddress("loan.cleris@gmail.com");
            const string fromPassword = "HVM2019'";
            string subject = "Reponse à votre demande de visite";
            string bodyAccept = "Ceci est un message automatique envoyé par l'application HVM /n /n" +
                "Bonjour, /n" + "";
           
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