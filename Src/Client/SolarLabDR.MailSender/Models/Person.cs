using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarLabDR.MailSender.Models
{
    public class Person
    {
        Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }
        public string? Email { get; set; }
    }
}
