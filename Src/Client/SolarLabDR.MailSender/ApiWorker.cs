using Newtonsoft.Json;
using SolarLabDR.MailSender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarLabDR.MailSender
{
    public class APIWorker
    {
        private readonly string _apiAdress;

        public APIWorker(string apiAdress)
        {
            _apiAdress = apiAdress;
        }

        public async Task<ICollection<Person>> GetPersonsAsync()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(_apiAdress);

                    var responseContent = await response.Content.ReadAsStringAsync();
                    var personResponse = JsonConvert.DeserializeObject<ICollection<Person>>(responseContent);

                    return personResponse;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }
    }
}
