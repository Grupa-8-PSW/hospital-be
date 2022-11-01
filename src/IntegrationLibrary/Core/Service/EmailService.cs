using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationLibrary.Core.Model;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using IntegrationLibrary.Core.Service.Interfaces;

namespace IntegrationLibrary.Core.Service
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;

        }

        public void SendEmail(string emailBB, string password, string API)
        {
            var email = new MimeMessage();
            GenerateEmail(email, emailBB,  password,  API);
            
            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);

            smtp.Send(email);
            smtp.Disconnect(true);

        }

        private void GenerateEmail(MimeMessage email, string address, string password, string api)
        {

            string body = "password: " + password + "   api: " + api;
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
            email.To.Add(MailboxAddress.Parse(address));

            
            email.Subject = "Registered user";
            email.Body = new TextPart(TextFormat.Html) { Text = body };
        }

    }
}

