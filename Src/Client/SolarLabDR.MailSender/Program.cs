using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SolarLabDR.MailSender.Models;

namespace SolarLabDR.MailSender
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var personsToСongratulate = new List<Person>() { new Person() { LastName = "name", Date = DateTime.Now, Name = "Name" } };
            var emailWorker = new EmailWorker(personsToСongratulate);

            //var builder = Host.CreateApplicationBuilder(args);
            //builder.Services.AddHostedService<MainWorker>();

            //var host = builder.Build();
            //host.Run();

        }
    }
}
