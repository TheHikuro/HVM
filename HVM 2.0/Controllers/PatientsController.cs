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
        private Entities db = new Entities();
        
        public ActionResult Index()
        {
            object sess = Session["p_Patient"];
            int idPatient = 0;
            int crnPris = 0 ;
            ;

            foreach (var usr in db.Utilisateur)
            {
                if (Session["p_Patient"].ToString() == usr.login.Trim())
                    idPatient = usr.id_patient;
            }

            if (Request.HttpMethod == "POST")
            {
                   if(Request.Form["accept"] != null)
                   {
                        foreach (var item in db.Creneau)
                        {
                            if (item.id_creneau == Int32.Parse(Request.Form["idCreneau"]))
                            {
                                item.disponibilite = false; item.reserve = false;
                                crnPris = item.id_creneau;
                            }
                        }
                        db.SaveChanges();
                        return RedirectToAction("Mail", "Patients", new { crnPris });
                   }

                   if(Request.Form["refus"] != null)
                   {
                        foreach (var item in db.Creneau)
                        {
                            if (item.id_creneau == Int32.Parse(Request.Form["idCreneau"]))
                            {
                                item.reserve = false;
                                crnPris = item.id_creneau;
                            }
                        }
                        db.SaveChanges();
                        return RedirectToAction("mailRefus", "Patients", new { crnPris });
                   }
            }

            List<Creneau> crnList = new List<Creneau>();
            crnList = db.Creneau.ToList();
            crnList.Reverse();
            all All = new all(); All.crenaux = crnList;  db.Creneau.ToList().Reverse(); All.patients = db.Utilisateur.ToList(); All.reserves = db.Reserve.ToList(); All.visiteurs = db.Visiteur.ToList();
            db.SaveChanges();

            return View(All);
        }
        
        public ActionResult Mail(int crnPris)
        {
            int idPatient = 0;
            String nomVisiteur = null, prenomVisiteur = null, mailVisiteur = null, nomPatient = null;
            Creneau crn = db.Creneau.Find(crnPris);
            foreach (var item in db.Creneau)
            {
                foreach (var usr in db.Utilisateur)
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
            "Nous vous confirmons votre RDV avec" + nomPatient + "le" + crn.date + "/n" +
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

        public ActionResult mailRefus(int crnPris)
        {
            int idPatient = 0;
            String nomVisiteur = null, prenomVisiteur = null, mailVisiteur = null, nomPatient = null;
            Creneau crn = db.Creneau.Find(crnPris);
            foreach (var item in db.Creneau)
            {
                foreach (var usr in db.Utilisateur)
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
            "Nous vous informons que" + nomPatient + "à refusé la demande de visite le " + crn.date + 
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

