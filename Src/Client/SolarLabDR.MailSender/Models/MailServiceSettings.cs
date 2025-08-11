using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarLabDR.MailSender.Models
{
    public class MailServiceSettings
    {
        public string EmailFrom { get; set; }
        public string ServerSMTP { get; set; }
        public int Port { get; set; }
        public string CredentialUserName { get; set; }
        public string CredentialPassword { get; set; }
    }
}
