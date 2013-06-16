using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio;

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

        private const string AccountSid = "AC5160b29cfe7044fb634bfe449a47a0c8";
        private const string AuthToken = "17f74b6c0648f4feabc0a8844fa6665a";
        public ActionResult MessageReceived(string from, string to, string body)
        {
            var client = new TwilioRestClient(AccountSid, AuthToken);
            client.SendSmsMessage("+18162988944", from, body);

            return Content(body, "text/plain");

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
