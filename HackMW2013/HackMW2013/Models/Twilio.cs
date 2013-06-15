using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using Twilio;

namespace HackMW2013.Models
{
    public class Twilio
    {
        private const string AccountSid = "AC5160b29cfe7044fb634bfe449a47a0c8";
        private const string AuthToken = "17f74b6c0648f4feabc0a8844fa6665a";

        public void SendSms(string accountNumber, string outgoingNumber)
        {
            var client = new TwilioRestClient(AccountSid, AuthToken);
            client.SendSmsMessage(accountNumber, outgoingNumber, "Texting Works this way.");
        }
    }
}