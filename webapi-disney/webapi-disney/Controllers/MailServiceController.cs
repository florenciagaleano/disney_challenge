using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAPIDisney.Controllers
{
    public class MailServiceController : Controller
    {
        public async Task SendMail(string mail, string subject, string htmlContent)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("disneywebapi@gmail.com","Prueba");
            var to = new EmailAddress(mail);
            var plainText = Regex.Replace(htmlContent, "<[^>]*>", "");
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainText, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
