using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;

namespace WWW.Controllers
{
    public class ContactController : Controller
    {
        [ActionName("subscribe")]
        public ActionResult Subscribe(string mail)
        {
            MailMessage message = new MailMessage()
            {
                From = new MailAddress("contact@arachne-cms.com"),
            };

            message.To.Add(message.From);
            message.Subject = "Subscription";
            message.Body = mail;

            SmtpClient client = new SmtpClient();
            client.Send(message);

            return this.Content("");
        }
    }
}
