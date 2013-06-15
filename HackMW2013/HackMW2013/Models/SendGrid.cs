using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace HackMW2013.Models
{
    public class SendGrid
    {
        public void SendMail(string emailTo, string Inviter)
        {
            MailMessage mailMsg = new MailMessage();

            // To
            mailMsg.To.Add(new MailAddress(emailTo, "To Name"));

            // From
            mailMsg.From = new MailAddress("invites@teamwubwub.com", "From Name");

            // Subject and multipart/alternative Body
            mailMsg.Subject = "subject";
            Guid inviteId;
            inviteId = Guid.NewGuid();
            string messageBody = string.Format(@"<p>{0} has invited you to SignalFlare, a calling tree application that makes notifying friends and family quicker and more efficient<br />Please click the link below to join {0}<br /><br /><a href='{1}'",
                Inviter, "http://teamwubwub.com/callingtree/" + inviteId);
            
            
            // Init SmtpClient and send
            SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("username@domain.com", "yourpassword");
            smtpClient.Credentials = credentials;

            smtpClient.Send(mailMsg);
        }
    }
}