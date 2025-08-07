using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarLabDR.Contracts.Image
{
    public class ImageResponse
    {
        public Guid? Id { get; set; }
        public byte[] bytes { get; set; }
        public Guid PersonId { get; set; }
    }
}
