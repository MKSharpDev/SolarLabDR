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
                                "..", "..", ".." // Поднимаемся на 3 уровня вверх из bin/Debug/net8.0
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
                string head = "Hello Test!"; 
                string smtpserver = _settings.ServerSMTP;

                SmtpClient client = new SmtpClient(smtpserver)
                {
                    Port = _settings.Port,
                    Credentials = new NetworkCredential(_settings.CredentialUserName, _settings.CredentialPassword),
                    EnableSsl = true
                };

                foreach (var emailTo in _toHRsMailCollection)
                {
                    client.Send(from, emailTo, head, body.ToString());
                    Console.WriteLine($"Email to HR {emailTo} was sent at {DateTime.Now}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task SendEmailToPersonDrAsync()
        {
            try
            {
                string from = _settings.EmailFrom;
                string head = "Поздравляем с ДНЕМ РОЖДЕНИЯ"; // Тема письма
                string smtpserver = _settings.ServerSMTP;

                SmtpClient client = new SmtpClient(smtpserver)
                {
                    Port = _settings.Port,
                    Credentials = new NetworkCredential(_settings.CredentialUserName, _settings.CredentialPassword),
                    EnableSsl = true
                };

                foreach (var emailTo in _personsToСongratulate)
                {
                    if (emailTo.Email == null)
                        continue;

                    var body = $"Уважаемый {emailTo.Name} {emailTo.LastName} в этот чуд.. бла бла бла ... поздравляем с ДР!";

                    client.Send(from, emailTo.Email, head, body);
                    Console.WriteLine($"Email to HR {emailTo.Email} was sent at {DateTime.Now}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
