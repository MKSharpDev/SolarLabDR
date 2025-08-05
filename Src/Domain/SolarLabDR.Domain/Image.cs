using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarLabDR.Domain
{
    public class Image : BaseEntity
    {
        public byte[] bytes { get; set; }
        public Guid PersonId { get; set; }
        public Person Person { get; set; }
    }
}
