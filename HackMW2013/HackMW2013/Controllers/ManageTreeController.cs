using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HackMW2013.Models;
using HackMW2013.ViewModels.ManageTree;

namespace HackMW2013.Controllers
{
    public class ManageTreeController : Controller
    {
        //
        // GET: /ManageTree/Index/{id}

        private readonly CallingTreeModelContainer _context = new CallingTreeModelContainer();

        public ActionResult Index(int id)
        {
            var model = new ManageTreeModel()
                {
                    Tree = _context.Trees.SingleOrDefault(x => x.Id == id)
                };

            if (model.Tree == null)
                throw new HttpException(404, String.Format("Tree id {0} not found", id));

            return View(model);
        }

        [HttpPost]
        public ActionResult AddMember(int id, ManageTreeModel model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            var tree = _context.Trees.SingleOrDefault(x => x.Id == id);

            if (tree == null)
                throw new HttpException(404, String.Format("Tree id {0} not found", id));

            tree.Members.Add(new Member()
                {
                    Name = model.Name,
                    PhoneNumber = model.Phone,
                    Email = model.Email
                });

            _context.SaveChanges();

            return RedirectToAction("Index", new { id });
        }

    }
}
