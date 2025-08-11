using FluentScheduler;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarLabDR.MailSender
{
    public class MainWorker : BackgroundService
    {
        public async Task MainTaskAsync() 
        {
            var adress = "https://localhost:7130/api/Persons/Birthdays/ByDate";
            var apiWorker = new APIWorker(adress);

            var personsToСongratulate = await apiWorker.GetPersonsAsync();

            if (!personsToСongratulate.Any())
                return;

            //string[] toHRs = { "kuzz.ma@yandex.ru" };
            var emailWorker = new EmailWorker(personsToСongratulate);

            await emailWorker.SendEmailToHRAsync();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            JobManager.Initialize();
            JobManager.AddJob( async () => await MainTaskAsync(),
                 s => s.ToRunEvery(1).Days().At(12, 37)
                );
          

            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine("Working... Time now: " + DateTime.Now.ToString());
                await Task.Delay(10000, stoppingToken);
            }

            if (stoppingToken.IsCancellationRequested)
                Console.WriteLine("Job cancellation requested.");

            JobManager.Stop();
        }
    }
}
