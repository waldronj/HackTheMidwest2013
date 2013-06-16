using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HackMW2013.Models;
using Twilio;

namespace HackMW2013.Controllers
{
    public class CallingTreeController : Controller
    {
        private readonly CallingTreeModelContainer _context = new CallingTreeModelContainer();

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

        private const string AccountSid = "AC7dbe24fc85a63e2ac866490e9948cd44";
        private const string AuthToken = "622a3e74b340d1d78f478d1a3a2e8ae4";
        public ActionResult MessageReceived(string from, string to, string body)
        {
            var client = new TwilioRestClient(AccountSid, AuthToken);
            var numbersToText = GetMemberPhoneNumbers(from);
            foreach (var item in numbersToText)
            {
                client.SendSmsMessage("+18162988944", item, body);    
            }
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

        public IEnumerable<string> GetMemberPhoneNumbers(string texter)
        {
            List<string> numbers = new List<string>();
            foreach (var member in _context.Members.Where(x => x.PhoneNumber == texter))
            {
                foreach (var m in member.Tree.Members)
                {
                    if (!numbers.Contains(m.PhoneNumber))
                        numbers.Add(m.PhoneNumber);
                }
            }

            return numbers;
        }
    }
}
