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


namespace IntegrationLibrary.Core.Service
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;

        }

        public void SendEmail(EmailDTO request)
        {
            var email = new MimeMessage();
            GenerateEmail(email, request.email);
            
            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);

            smtp.Send(email);
            smtp.Disconnect(true);

        }

        private void GenerateEmail(MimeMessage email, string address)
        {

            string body = "";
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
            email.To.Add(MailboxAddress.Parse(address));

            
            email.Subject = "Registered user";
            email.Body = new TextPart(TextFormat.Html) { Text = body };
        }

        private string AddGeneratedPasswordInEmail()
        {
            return  CreateDummyString(8);
        }

        private string AddGeneratedAPIkeyInEmail()
        {
            return  CreateDummyString(36);
        }


        private string CreateDummyString(int length)
        {
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
            Random random = new Random();

            char[] chars = new char[length];

            for (int i = 0; i < length; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }
    }
}
