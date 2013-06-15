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
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            SendSms();

            return View();
        }

        private const string AccountSid = "AC5160b29cfe7044fb634bfe449a47a0c8";
        private const string AuthToken = "17f74b6c0648f4feabc0a8844fa6665a";

        public void SendSms()
        {
            var client = new TwilioRestClient(AccountSid, AuthToken);
            client.SendSmsMessage("+18162988944", "+19139614662", "Texting Works this way.");
        }

        public void GetSms()
        {
            var client = new TwilioRestClient(AccountSid, AuthToken);
            


        }

    }
}
