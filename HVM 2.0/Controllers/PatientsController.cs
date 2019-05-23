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
        
        public ActionResult Index()
        {
            int idCreneau;
            object sess = Session["p_Patient"];
            int idPatient = 0;
            String crnPris = Request.Form["CreneauxPris"];

            foreach (var usr in db.Patient)
            {
                if (Session["p_Patient"].ToString() == usr.login.Trim())
                    idPatient = usr.id_patient;
            }

            if (Request.HttpMethod == "POST")
            {
                if (Request.Form["CreneauxPris"] != null)
                {
                   if(Request.Form["accept"] != null)
                   {
                        foreach (var item in db.Creneau)
                        {
                            if (item.date.ToString().Trim() == crnPris.Split('|')[0].Trim() && item.id_patient == idPatient)
                            {
                                item.disponibilite = false; item.reserve = false;
                                idCreneau = item.id_creneau;
                            }
                        }
                        db.SaveChanges();
                        return RedirectToAction("Mail", "Patients", new { crnPris });
                   }

                   if(Request.Form["refus"] != null)
                   {
                        foreach (var item in db.Creneau)
                        {
                            if (Request.Form["CreneauxPris"].Split('|')[0].Trim() == item.date.ToString().Trim() && idPatient == item.id_patient)
                            {
                                item.reserve = false;
                                return RedirectToAction("mailRefus", "Patients", new { crnPris });
                            }
                        }
                   }
                }
            }

            all All = new all(); All.crenaux = db.Creneau.ToList(); All.patients = db.Patient.ToList(); All.reserves = db.Reserve.ToList(); All.visiteurs = db.Visiteur.ToList();
            db.SaveChanges();

            return View(All);
        }
        
        public ActionResult Mail(String crnPris)
        {
            int idPatient = 0;
            String nomVisiteur = null, prenomVisiteur = null, mailVisiteur = null, nomPatient = null;
        
            foreach (var item in db.Creneau)
            {
                foreach (var usr in db.Patient)
                {
                    if (Session["p_Patient"].ToString() == usr.login.Trim())
                    {
                        idPatient = usr.id_patient;
                        nomPatient = usr.nom;
                    }
                }

                foreach (var res in db.Reserve)
                {
                    if (res.id_Creneau == item.id_creneau)
                    {
                        foreach (var vis in db.Visiteur)
                        {
                            if (res.id_Visiteur == vis.id_Visiteur)
                            {
                                prenomVisiteur = vis.prenom;
                                nomVisiteur = vis.nom;
                                mailVisiteur = vis.mail;
                            }
                        }
                    }
                }
            }
            var fromAdress = new MailAddress("Hopital.Manager@gmail.com", "HVM");
            var toAddress = new MailAddress(mailVisiteur);
            const string fromPassword = "HVM2019'";
            string subject = "Reponse à votre demande de visite";
            string bodyAccept = "Ceci est un message automatique envoyé par l'application HVM /n /n" +
                    "Bonjour Mr/Mme" + nomVisiteur + "/n" +
            "Nous vous confirmons votre RDV avec" + nomPatient + "le" + crnPris + "/n" +
            "Merci de ne pas repondre à ce mail";

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

        public ActionResult mailRefus(String crnPris)
        {
            int idPatient = 0;
            String nomVisiteur = null, prenomVisiteur = null, mailVisiteur = null, nomPatient = null;
           
            foreach (var item in db.Creneau)
            {
                foreach (var usr in db.Patient)
                {
                    if (Session["p_Patient"].ToString() == usr.login.Trim())
                    {
                        idPatient = usr.id_patient;
                        nomPatient = usr.nom.Trim();
                    }
                }

                foreach (var res in db.Reserve)
                {
                    if (res.id_Creneau == item.id_creneau)
                    {
                        foreach (var vis in db.Visiteur)
                        {
                            if (res.id_Visiteur == vis.id_Visiteur)
                            {
                                prenomVisiteur = vis.prenom.Trim();
                                nomVisiteur = vis.nom.Trim();
                                mailVisiteur = vis.mail.Trim();
                            }
                        }
                    }
                }
            }
            var fromAdress = new MailAddress("Hopital.Manager@gmail.com", "HVM");
            var toAddress = new MailAddress(mailVisiteur);
            const string fromPassword = "HVM2019'";
            string subject = "Reponse à votre demande de visite";
            string bodyRefus = "Ceci est un message automatique envoyé par l'application HVM /n /n" +
                    "Bonjour Mr/Mme" + nomVisiteur + "/n" +
            "Nous vous informons que" + nomPatient + "à refusé la demande de visite le " + crnPris + 
            "Merci de ne pas repondre à ce mail";

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
                    using (var message = new MailMessage { Subject = subject, Body = bodyRefus })
                    {
                        SmtpClient.Send(message);
                    }
                }

            }

            return View();
        }

    }

   

}

