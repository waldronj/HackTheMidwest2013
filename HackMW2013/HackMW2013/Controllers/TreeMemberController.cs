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
    public class TreeMemberController : Controller
    {
        private CallingTreeModelContainer db = new CallingTreeModelContainer();

        //
        // GET: /TreeMember/

        public ActionResult Index()
        {
            return View(db.TreeMembers.ToList());
        }

        //
        // GET: /TreeMember/Details/5

        public ActionResult Details(int id = 0)
        {
            TreeMember treemember = db.TreeMembers.Find(id);
            if (treemember == null)
            {
                return HttpNotFound();
            }
            return View(treemember);
        }

        //
        // GET: /TreeMember/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TreeMember/Create

        [HttpPost]
        public ActionResult Create(TreeMember treemember)
        {
            if (ModelState.IsValid)
            {
                db.TreeMembers.Add(treemember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(treemember);
        }

        //
        // GET: /TreeMember/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TreeMember treemember = db.TreeMembers.Find(id);
            if (treemember == null)
            {
                return HttpNotFound();
            }
            return View(treemember);
        }

        //
        // POST: /TreeMember/Edit/5

        [HttpPost]
        public ActionResult Edit(TreeMember treemember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(treemember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(treemember);
        }

        //
        // GET: /TreeMember/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TreeMember treemember = db.TreeMembers.Find(id);
            if (treemember == null)
            {
                return HttpNotFound();
            }
            return View(treemember);
        }

        //
        // POST: /TreeMember/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            TreeMember treemember = db.TreeMembers.Find(id);
            db.TreeMembers.Remove(treemember);
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