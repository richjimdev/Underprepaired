using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Underprepaired.Models
{
    public class EmailSender : IEmailSender
    {
        public IConfiguration Configuration { get; }

        public EmailSender(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SendGridClient(Configuration["SendGrid_Api_Key"]);

            var msg = new SendGridMessage();

            msg.SetFrom("admin@underprepaired.shop");

            msg.AddTo(email);
            msg.AddContent(MimeType.Html, htmlMessage);

            await client.SendEmailAsync(msg);
        }
    }
}
