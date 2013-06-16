using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HackMW2013.Filters;
using HackMW2013.Models;
using HackMW2013.ViewModels.ManageTree;
using WebMatrix.WebData;

namespace HackMW2013.Controllers
{
    [InitializeSimpleMembership]
    [Authorize]
    public class ManageTreeController : Controller
    {
        private readonly CallingTreeModelContainer _context = new CallingTreeModelContainer();

        public int UserId { get { return WebSecurity.GetUserId(User.Identity.Name); } }

        public ActionResult Index()
        {
            var model = new ManageTreesModel
                {
                    Trees = _context.Trees.Where(x => x.OwnerId == UserId).ToList()
                };

            return View("ManageTrees", model);
        }

        public ActionResult AddTree(ManageTreesModel model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            var tree = new Tree
                {
                    Name = model.Name,
                    OwnerId = UserId
                };

            tree = _context.Trees.Add(tree);
            _context.SaveChanges();

            return RedirectToAction("ViewTree", new {id = tree.Id});
        }

        public ActionResult ViewTree(int id)
        {
            var model = new ManageTreeModel
                {
                    Tree = _context.Trees.SingleOrDefault(x => x.Id == id)
                };

            if (model.Tree == null || model.Tree.OwnerId != UserId)
                throw new HttpException(404, String.Format("Tree id {0} not found", id));

            return View("Index", model);
        }

        [HttpPost]
        public ActionResult AddMember(int id, ManageTreeModel model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("ViewTree");

            var tree = _context.Trees.SingleOrDefault(x => x.Id == id);

            if (tree == null || tree.OwnerId != UserId)
                throw new HttpException(404, String.Format("Tree id {0} not found", id));

            tree.Members.Add(new Member
                {
                    Name = model.Name,
                    PhoneNumber = model.Phone,
                    Email = model.Email
                });

            _context.SaveChanges();

            return RedirectToAction("ViewTree", new {id});
        }

        [HttpPost]
        public void EditMember(int id, int memberId, string name, string phone, string email)
        {
            var tree = _context.Trees.SingleOrDefault(x => x.Id == id);

            if (tree == null || tree.OwnerId != UserId)
                throw new HttpException(404, String.Format("Tree id {0} not found", id));

            var member = tree.Members.SingleOrDefault(x => x.Id == memberId);

            if (member == null)
                throw new HttpException(404, String.Format("Member id {0} not found", memberId));

            member.Name = name;
            member.PhoneNumber = phone;
            member.Email = email;

            _context.SaveChanges();
        }

        [HttpPost]
        public void RemoveMember(int id, int memberId)
        {
            var tree = _context.Trees.SingleOrDefault(x => x.Id == id);

            if (tree == null || tree.OwnerId != UserId)
                throw new HttpException(404, String.Format("Tree id {0} not found", id));

            var member = tree.Members.SingleOrDefault(x => x.Id == memberId);

            tree.Members.Remove(member);
            _context.Members.Remove(member);

            _context.SaveChanges();
        }
    }
}
