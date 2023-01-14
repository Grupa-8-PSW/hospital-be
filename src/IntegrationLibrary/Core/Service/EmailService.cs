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
using HospitalLibrary.Core.Model;
using System.Net.Mail;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using System.Net.Http;
using System.Reflection.Metadata;

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

        public async void SendEmail(string emailBB, string password, string API)
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
            string bloodRequestRoutingKey = _config.GetSection("bloodRequestRoutingKey").Value;
            string bloodRequestExchange = _config.GetSection("bloodRequestExchange").Value;
            template.AppendLine("<p><h3>Blood Request routing key: " + bloodRequestRoutingKey + "</h3></p>");
            template.AppendLine("<p><h3>Blood Request exchange: " + bloodRequestExchange + "</h3></p>");
            string hospitalQueue = _config.GetSection("hospitalQueue").Value;
            template.AppendLine("<p><h3>Hospital receiving queue: " + hospitalQueue + "</h3></p>");
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
            email.To.Add(MailboxAddress.Parse(address));
            email.Subject = "Your bank has been successfully registered";
            email.Body = new TextPart(TextFormat.Html) { Text = template.ToString() };
        }

        public async void SendSuccessEmail(string emailBB, int tenderId, string APIKey)
        {
            var successEmail = new MimeMessage();
            GenerateSuccessTenderEmail(successEmail, emailBB, tenderId, APIKey);
            SmtpClient smtp = SetupSmtpClient(successEmail);
        }

        public async void SendRejectEmail(string emailBB)
        {

            var rejectEmail = new MimeMessage();
            GenerateRejectTenderEmail(rejectEmail, emailBB);
            SmtpClient smtp =  SetupSmtpClient(rejectEmail);
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

        public void SendRejectMonthlyDeliveryEmail(string date)
        {
            var rejectEmail = new MimeMessage();
            GenerateRejectMonthlyDeliveryMail(rejectEmail, date);
            SmtpClient smtp = SetupSmtpClient(rejectEmail);
        }

        public void GenerateRejectMonthlyDeliveryMail(MimeMessage email, string Date)
        {
            rejectTemplate.AppendLine("<b><h1>***Monthly Delivery Canceled***</h1></b>");
            rejectTemplate.AppendLine("<p>Monthly Delivery for "+ Date + " has been canceled" + "</p>");
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
            email.To.Add(MailboxAddress.Parse("davidmijailovic9@gmail.com"));
            email.Subject = "Sorry, monthly delivery has been canceled";
            email.Body = new TextPart(TextFormat.Html) { Text = rejectTemplate.ToString() };

        }

        public void sendPDFReportAttached(byte[] myFileAsByteArray)
        {
            var message = new MimeMessage();
            

            message.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
            message.To.Add(MailboxAddress.Parse("rbojan2000@gmail.com"));
            message.Subject = "Blood consumption report";


            var builder = new BodyBuilder();

            builder.Attachments.Add("./Reports/report" + ".PDF");

            message.Body = builder.ToMessageBody();
            SmtpClient smtp = SetupSmtpClient(message);

        }
    }
}

