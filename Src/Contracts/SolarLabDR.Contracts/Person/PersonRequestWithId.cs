using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarLabDR.Contracts.Person
{
    public class PersonRequestWithId : PersonRequest
    {
        public Guid Id { get; set; }
    }
}
