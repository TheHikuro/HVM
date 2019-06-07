﻿using System;
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
            return View(db.Visiteur.ToList());
        }

        // GET: Visiteurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visiteur visiteur = db.Visiteur.Find(id);
            if (visiteur == null)
            {
                return HttpNotFound();
            }
            return View(visiteur);
        }

        // GET: Visiteurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Visiteurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Visiteur,prenom,nom,mail")] Visiteur visiteur)
        {
            if (ModelState.IsValid)
            {
                db.Visiteur.Add(visiteur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(visiteur);
        }

        // GET: Visiteurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visiteur visiteur = db.Visiteur.Find(id);
            if (visiteur == null)
            {
                return HttpNotFound();
            }
            return View(visiteur);
        }

        // POST: Visiteurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Visiteur,prenom,nom,mail")] Visiteur visiteur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visiteur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(visiteur);
        }

        // GET: Visiteurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visiteur visiteur = db.Visiteur.Find(id);
            if (visiteur == null)
            {
                return HttpNotFound();
            }
            return View(visiteur);
        }

        // POST: Visiteurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Visiteur visiteur = db.Visiteur.Find(id);
            db.Visiteur.Remove(visiteur);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}