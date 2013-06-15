using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HackMW2013.Models;

namespace HackMW2013.Controllers
{
    public class TreeChatController : Controller
    {
        private CallingTreeModelContainer db = new CallingTreeModelContainer();

        //
        // GET: /TreeChat/

        public ActionResult Index()
        {
            return View(db.Chats.ToList());
        }

        //
        // GET: /TreeChat/Details/5

        public ActionResult Details(int id = 0)
        {
            Chat chat = db.Chats.Find(id);
            if (chat == null)
            {
                return HttpNotFound();
            }
            return View(chat);
        }

        //
        // GET: /TreeChat/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TreeChat/Create

        [HttpPost]
        public ActionResult Create(Chat chat)
        {
            if (ModelState.IsValid)
            {
                db.Chats.Add(chat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chat);
        }

        //
        // GET: /TreeChat/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Chat chat = db.Chats.Find(id);
            if (chat == null)
            {
                return HttpNotFound();
            }
            return View(chat);
        }

        //
        // POST: /TreeChat/Edit/5

        [HttpPost]
        public ActionResult Edit(Chat chat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chat);
        }

        //
        // GET: /TreeChat/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Chat chat = db.Chats.Find(id);
            if (chat == null)
            {
                return HttpNotFound();
            }
            return View(chat);
        }

        //
        // POST: /TreeChat/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Chat chat = db.Chats.Find(id);
            db.Chats.Remove(chat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}