using HospitalLibrary.Core.Model;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;


namespace HospitalLibrary.Core.Service
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;

        }

        public void SendEmail(EmailDto request)
        {
            var email = new MimeMessage();
            string address = request.email;

            GenerateEmail(email, address);

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
