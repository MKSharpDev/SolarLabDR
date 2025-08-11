using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarLabDR.Contracts.Person
{
    public class PersonRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }
        public string? Email { get; set; }
    }
}
