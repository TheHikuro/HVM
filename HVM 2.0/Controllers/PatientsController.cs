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
            Creneau crnPris = new Creneau();
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
                                crnPris = item;
                            }
                        }
                        db.SaveChanges();
                        Mail(crnPris);
                   }
                   else if (Request.Form["refus"] != null)
                   {
                        foreach (var item in db.Creneau)
                        {
                            if (item.id_creneau == Int32.Parse(Request.Form["idCreneau"]))
                            {
                                item.reserve = false;
                                crnPris = item;
                            }
                        }
                        db.SaveChanges();
                        mailRefus(crnPris);
                   }
            }

            List<Creneau> crnList = new List<Creneau>();
            crnList = db.Creneau.ToList();
            crnList.Reverse();
            all All = new all(); All.crenaux = crnList;  db.Creneau.ToList().Reverse(); All.patients = db.Utilisateur.ToList(); All.reserves = db.Reserve.ToList(); All.visiteurs = db.Visiteur.ToList();
            db.SaveChanges();

            return View(All);
        }
        
        public void Mail(Creneau crnPris)
        {
            int idPatient = 0;
            String nomVisiteur = null, prenomVisiteur = null, mailVisiteur = null, nomPatient = null, prenomPatient = null;
            DateTime? dateCrn = crnPris.date;
            Chambre chambrePatient = new Chambre();
            
            foreach (var usr in db.Utilisateur)
            {
                if (Session["p_Patient"].ToString() == usr.login.Trim())
                {
                    idPatient = usr.id_patient;
                    nomPatient = usr.nom;
                    prenomPatient = usr.prenom;
                }
            }

            foreach (var res in db.Reserve)
            {
                if (res.id_Creneau == crnPris.id_creneau)
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
            foreach(var poss in db.Possede)
            {
                if (poss.id_Patient == idPatient)
                {
                    chambrePatient = db.Chambre.Find(poss.id_chambre);
                }
            }
            var fromAdress = new MailAddress("Hopital.Manager@gmail.com", "Hopital Innovation Aforp");
            var toAddress = new MailAddress(mailVisiteur, "loan.cleris@gmail.com");
            const string fromPassword = "HVM2019Z";
            string subject = "Reponse à votre demande de visite";
            string bodyAccept = "Bonjour Mr/Mme " + nomVisiteur + "\n \n" +
            "Nous vous confirmons votre RDV avec " + prenomPatient+ " " + nomPatient + " du " + dateCrn.ToString() + "\n" +
            "Veuillez vous rendre au batiment " + chambrePatient.batiment + ", la chambre porte le numéro " + chambrePatient.numero + " située à l'étage " + chambrePatient.etage + "\n\n" +
            "Ceci est un message automatique envoyé par l'application HVM, merci de ne pas y répondre";

            var Smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential(fromAdress.Address, fromPassword)
            };
            using (var message_a = new MailMessage(fromAdress, toAddress) { Subject = subject, Body = bodyAccept })
            {
                Smtp.Send(message_a);
            }
        }

        public void mailRefus(Creneau crnPris)
        {
            int idPatient = 0;
            String nomVisiteur = null, prenomVisiteur = null, mailVisiteur = null, nomPatient = null, prenomPatient = null;
            DateTime? dateCrn = crnPris.date;
            Chambre chambrePatient = new Chambre();

            foreach (var usr in db.Utilisateur)
            {
                if (Session["p_Patient"].ToString() == usr.login.Trim())
                {
                    idPatient = usr.id_patient;
                    nomPatient = usr.nom;
                    prenomPatient = usr.prenom;
                }
            }
            foreach (var res in db.Reserve)
            {
                if (res.id_Creneau == crnPris.id_creneau)
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
            foreach (var poss in db.Possede)
            {
                if (poss.id_Patient == idPatient)
                {
                    chambrePatient = db.Chambre.Find(poss.id_chambre);
                }
            }

            var fromAdress = new MailAddress("Hopital.Manager@gmail.com", "Hopital Innovation Aforp");
            var toAddress = new MailAddress("t.martin92500@hotmail.fr");
            const string fromPassword = "HVM2019Z";
            string subject = "Reponse à votre demande de visite";
            string bodyRefus = "Bonjour Mr/Mme " + nomVisiteur + "\n \n" +
         "Votre RDV avec " + prenomPatient + " " + nomPatient + " du " + dateCrn.ToString() + " à été refusé.\n" +
         "Ceci est un message automatique envoyé par l'application HVM, merci de ne pas y répondre";

            var SmtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential(fromAdress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAdress, toAddress) { Subject = subject, Body = bodyRefus })
            {
                SmtpClient.Send(message);
            }
        }
    }
}


