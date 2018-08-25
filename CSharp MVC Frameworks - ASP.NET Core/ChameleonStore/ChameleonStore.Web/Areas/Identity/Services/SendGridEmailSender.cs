using AutoMapper.Configuration;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChameleonStore.Web.Areas.Identity.Services
{
    public class SendGridEmailSender : IEmailSender
    {
        private const string ApiKey = "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";

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SendGridClient(ApiKey);
            var from = new EmailAddress("admin@chameleonStore.bg", "ChameleonStore Admin");
            var to = new EmailAddress(email, email);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, htmlMessage, htmlMessage);
            var response = await client.SendEmailAsync(msg);
            var body = await response.Body.ReadAsStringAsync();
            var statusCode = response.StatusCode;
        }
    }
}
