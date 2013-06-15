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
        private const string AccountSid = "AC7dbe24fc85a63e2ac866490e9948cd44";
        private const string AuthToken = "622a3e74b340d1d78f478d1a3a2e8ae4";

        public void SendSms(string phoneNumber, string messageBody)
        {
            var client = new TwilioRestClient(AccountSid, AuthToken);
            client.SendSmsMessage("+18162988944", "+19139614662", "Hey, you should work!");
        }
    }
}