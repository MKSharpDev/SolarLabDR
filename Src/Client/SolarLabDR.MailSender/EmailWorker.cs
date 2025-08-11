using Microsoft.Extensions.Configuration;
using SolarLabDR.MailSender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SolarLabDR.MailSender
{
    public class EmailWorker
    {
        public ICollection<Person> _personsToСongratulate;
        public ICollection<string> _toHRsMailCollection;
        public MailServiceSettings _settings;


        public EmailWorker(ICollection<Person> personsToСongratulate)
        {
            _personsToСongratulate = personsToСongratulate;

            var config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(
                                 Directory.GetCurrentDirectory(),
                                "..", "..", ".." // Поднимаемся на 3 уровня вверх из bin/Debug/netX.Y
                                ))
                .AddJsonFile("appsettings.json")
                .Build();

            var settings = config.GetSection("MailServiceSettings").Get<MailServiceSettings>();

            if (settings == null)
                throw new Exception("Необходимо добавить MailServiceSettings в appsettings.json");

            var toHRs = config.GetSection("HRsEmailList").Get <string[]>();

            if (toHRs == null || !toHRs.Any())
                throw new Exception("Необходимо добавить HRsEmailList в appsettings.json");

            _settings = settings;
            _toHRsMailCollection = toHRs;
        }

        public async Task SendEmailToHRAsync()
        {
            try
            {
                var body = new StringBuilder();
                body.AppendLine("Сегодня дР!!:");

                foreach (var person in _personsToСongratulate)
                    body.AppendLine(person.Name + " " + person.LastName);

                string from = _settings.EmailFrom;
                string head = "Hello Test!"; // Тема письма
                string smtpserver = _settings.ServerSMTP;

                SmtpClient client = new SmtpClient(smtpserver)
                {
                    Port = _settings.Port,
                    Credentials = new NetworkCredential(_settings.CredentialUserName, _settings.CredentialPassword),
                    EnableSsl = true
                };

                foreach (var emailTo in _toHRsMailCollection)            
                    client.Send(from, emailTo, head, body.ToString());
                
                Console.WriteLine($"Email was sent at {DateTime.Now}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();

            }
        }
    }
}
