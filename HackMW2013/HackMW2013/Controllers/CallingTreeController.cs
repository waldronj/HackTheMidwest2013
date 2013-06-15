using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HackMW2013.Controllers
{
    public class CallingTreeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Invite()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult Invite(string EmailAddresses)
        {
            if (User.Identity.IsAuthenticated)
            {
                string[] EmailAdressList = EmailAddresses.Split(',');
                foreach (string email in EmailAdressList)
                {
                    Guid testGuid;
                    testGuid = Guid.NewGuid();
                    ViewBag.testing += email + testGuid + " <br />";
                }
                return View("Test");
            }
            return View("Index");
        }

        public ActionResult EmailInvite(string InviteId)
        {
            return View("Success");
        }
    }
}
