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
        private StringBuilder template = new StringBuilder();
        private StringBuilder rejectTemplate = new StringBuilder();
        private StringBuilder successTemplate = new StringBuilder();
        
        public EmailService(IConfiguration config)
        {
            _config = config;

        }

        public void SendEmail(string emailBB, string password, string API)
        {
            var email = new MimeMessage();
            GenerateEmail(email, emailBB,  password,  API);
            SmtpClient smtp = SetupSmtpClient(email);

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

        public void SendSuccessEmail(string emailBB, int tenderId, string APIKey)
        {
            var successEmail = new MimeMessage();
            GenerateSuccessTenderEmail(successEmail, emailBB, tenderId, APIKey);
            SmtpClient smtp = SetupSmtpClient(successEmail);
        }

        public void SendRejectEmail(string emailBB)
        {

            var rejectEmail = new MimeMessage();
            GenerateRejectTenderEmail(rejectEmail, emailBB);
            SmtpClient smtp = SetupSmtpClient(rejectEmail);
        }

        private SmtpClient SetupSmtpClient(MimeMessage successEmail)
        {
            var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);

            smtp.Send(successEmail);
            smtp.Disconnect(true);
            return smtp;
        }

        private void GenerateSuccessTenderEmail(MimeMessage email, string address, int tenderId, string APIKey)
        {
            successTemplate.AppendLine("<b><h1>***SUCCESSFUL TENDER OFFER***</h1></b>");
            successTemplate.AppendLine("<a href='https://localhost:7131/api/TenderOffer/sendTenderOffer?tenderId=" + tenderId +"&APIKey="+ APIKey + "'"+ ">Confirm the tender offer</a>");
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
            email.To.Add(MailboxAddress.Parse("rbojan2000@gmail.com"));
            email.Subject = "Congratulations, your tender request has been accepted";
            email.Body = new TextPart(TextFormat.Html) { Text = successTemplate.ToString() };
           
        }

        private void GenerateRejectTenderEmail(MimeMessage email, string address)
        {
            rejectTemplate.AppendLine("<b><h1>***TENDER OFFER REJECTED***</h1></b>");
            rejectTemplate.AppendLine("<p>Sorry</p>");
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
            email.To.Add(MailboxAddress.Parse("davidmijailovic9@gmail.com"));
            email.Subject = "Sorry, your tender request has been rejected";
            email.Body = new TextPart(TextFormat.Html) { Text = rejectTemplate.ToString() };
        }

    }
}

