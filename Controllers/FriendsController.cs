﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IT_GAMK_Lab3.Models;

namespace IT_GAMK_Lab3.Controllers
{
    public class FriendsController : Controller
    {
        private FriendsContext db = new FriendsContext();

        // GET: Friends
        public ActionResult Index()
        {
            return View(db.friends.ToList());
        }

        // GET: Friends/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friend friend = db.friends.Find(id);
            if (friend == null)
            {
                return HttpNotFound();
            }
            return View(friend);
        }

        // GET: Friends/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Friends/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ime,MestoZiveenje")] Friend friend)
        {
            if (ModelState.IsValid)
            {
                db.friends.Add(friend);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(friend);
        }

        // GET: Friends/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friend friend = db.friends.Find(id);
            if (friend == null)
            {
                return HttpNotFound();
            }
            return View(friend);
        }

        // POST: Friends/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ime,MestoZiveenje")] Friend friend)
        {
            if (ModelState.IsValid)
            {
                db.Entry(friend).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(friend);
        }
        public ActionResult Delete(int id)
        {
            Friend friend = db.friends.Find(id);
            db.friends.Remove(friend);
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
