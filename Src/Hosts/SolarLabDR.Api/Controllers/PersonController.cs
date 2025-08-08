using Microsoft.AspNetCore.Mvc;
using SolarLabDR.AppServices.Context.Person.Service;
using SolarLabDR.Contracts.Image;
using SolarLabDR.Contracts.Person;
using System.Net;

namespace SolarLabDR.Api.Controllers
{
    [Route("api/Persons")]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await _personService.GetByIdAsync(id, cancellationToken);
            return StatusCode((int)HttpStatusCode.OK, result);
        }


        [HttpGet("birthdaybyMonth/{month:int}")]
        public async Task<IActionResult> GetByMonthBDAsync(int month, CancellationToken cancellationToken)
        {
            var resultList = await _personService.GetByMonthBDAsync(month, cancellationToken);
            return StatusCode((int)HttpStatusCode.OK, resultList);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] PersonRequest model, CancellationToken cancellationToken)
        {
            await _personService.CreateAsync(model, cancellationToken);
            return StatusCode((int)HttpStatusCode.Created);
        }
    }
}
