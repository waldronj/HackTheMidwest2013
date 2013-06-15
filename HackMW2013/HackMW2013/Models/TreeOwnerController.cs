using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HackMW2013.Models
{
    public class TreeOwnerController : Controller
    {
        private CallingTreeModelContainer db = new CallingTreeModelContainer();

        //
        // GET: /TreeOwner/

        public ActionResult Index()
        {
            return View(db.TreeOwners.ToList());
        }

        //
        // GET: /TreeOwner/Details/5

        public ActionResult Details(int id = 0)
        {
            TreeOwner treeowner = db.TreeOwners.Find(id);
            if (treeowner == null)
            {
                return HttpNotFound();
            }
            return View(treeowner);
        }

        //
        // GET: /TreeOwner/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TreeOwner/Create

        [HttpPost]
        public ActionResult Create(TreeOwner treeowner)
        {
            if (ModelState.IsValid)
            {
                db.TreeOwners.Add(treeowner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(treeowner);
        }

        //
        // GET: /TreeOwner/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TreeOwner treeowner = db.TreeOwners.Find(id);
            if (treeowner == null)
            {
                return HttpNotFound();
            }
            return View(treeowner);
        }

        //
        // POST: /TreeOwner/Edit/5

        [HttpPost]
        public ActionResult Edit(TreeOwner treeowner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(treeowner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(treeowner);
        }

        //
        // GET: /TreeOwner/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TreeOwner treeowner = db.TreeOwners.Find(id);
            if (treeowner == null)
            {
                return HttpNotFound();
            }
            return View(treeowner);
        }

        //
        // POST: /TreeOwner/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            TreeOwner treeowner = db.TreeOwners.Find(id);
            db.TreeOwners.Remove(treeowner);
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