﻿using MailKit.Security;
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
        private StringBuilder template = new StringBuilder();

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
            template.AppendLine("<b><h1>***SUCCESSFUL REGISTRATION***</h1></b>");
            template.AppendLine("<p><h3>Password: " + password + "</h3></p>");
            template.AppendLine("<p><h3>API Key: " + api + "</h3></p>");
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
            email.To.Add(MailboxAddress.Parse(address));
            email.Subject = "Your bank has been successfully registered";
            email.Body = new TextPart(TextFormat.Html) { Text = template.ToString() };
        }

        public void SendTenderEmail(string emailBB)
        {
            var email = new MimeMessage();
            GenerateSuccesTenderEmail(email, emailBB);

            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);

            smtp.Send(email);
            smtp.Disconnect(true);

        }

        private void GenerateSuccesTenderEmail(MimeMessage email, string address)
        {
            template.AppendLine("<b><h1>***SUCCESSFUL TENDER OFFER***</h1></b>");
            template.AppendLine("<a href='https://localhost:7131/api/BloodUnitUrgentRequest/sendTenderOffer'>Confirm the tender offer</a>");
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
            email.To.Add(MailboxAddress.Parse(address));
            email.Subject = "Congratulations, your tender request has been accepted";
            email.Body = new TextPart(TextFormat.Html) { Text = template.ToString() };
        }

    }
}

