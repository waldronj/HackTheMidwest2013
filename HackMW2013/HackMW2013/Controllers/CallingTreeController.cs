using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HackMW2013.Models;
using Twilio;
using log4net;
using System.Net.Mail;
using SendGridMail;
using System.Net;
using SendGridMail.Transport;

namespace HackMW2013.Controllers
{
    public class CallingTreeController : Controller
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(CallingTreeController));

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
            SendgridEmail(from, body);
            Logger.DebugFormat("*** Received text from {0}: {1}", from, body);
            var client = new TwilioRestClient(AccountSid, AuthToken);
            var SenderName = GetUserName(from.TrimStart('+'));
            var numbersToText = GetMemberPhoneNumbers(from.TrimStart('+'));
            foreach (var item in numbersToText)
            {
                if (item == from.TrimStart('+'))
                    continue;

                Logger.DebugFormat("    Sending text to {0}", item);
                client.SendSmsMessage("+18162988944", item, SenderName + body);
                Logger.DebugFormat("    Text sent to {0}", item);
            }            
            return Content(body, "text/plain");
        }

        public ActionResult TestEmail(string InviteId)
        {
            SendgridEmail("19139614662", "testing");
            return View("index");
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

        public string GetUserName(string PhoneNumberFrom)
        {
            var name = _context.Members.Where(x => x.PhoneNumber == PhoneNumberFrom).SingleOrDefault().Name.ToString();
            string UserName = name + ": ";
            return UserName;
        }

        public IEnumerable<string> GetEmailAddresses(string FromPhoneNumber)
        {
            List<string> emailList = new List<string>();
            foreach (var item in _context.Members.Where(x => x.PhoneNumber == FromPhoneNumber))
            {
                foreach (var m in item.Tree.Members)
                {
                    if (!emailList.Contains(m.Email))
                        emailList.Add(m.Email);
                }                
            }
            return emailList;
        }

        public void SendgridEmail(string fromPhoneNumber, string body)
        {
            var emailList = GetEmailAddresses(fromPhoneNumber);
            string Username = GetUserName(fromPhoneNumber);
            // Create the email object first, then add the properties.
            var myMessage = SendGrid.GetInstance();

            // Add the message properties.
            myMessage.From = new MailAddress("Notification@teamwubwub.com");

            // Add multiple addresses to the To field.
  

            myMessage.AddTo(emailList);

            myMessage.Subject = "Notification from SignalFlare";

            //Add the HTML and Text bodies
            myMessage.Html = "<p>"+ Username +  body + "</p>";
            myMessage.Text = Username + body;

            // Create network credentials to access your SendGrid account.
            var username = System.Configuration.ConfigurationSettings.AppSettings["SendUsername"];
            var pswd = System.Configuration.ConfigurationSettings.AppSettings["SendPassword"];

            var credentials = new NetworkCredential(username, pswd);

            // Create the email object first, then add the properties.
            

            // Create a Web transport for sending email.
            var transportWeb = Web.GetInstance(credentials);

            // Send the email.
            transportWeb.Deliver(myMessage);
        }
    }
}
