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


        [HttpGet("Birthdays/ByMonth/{month:int}")]
       public async Task<IActionResult> GetByMonthBDAsync(int month, CancellationToken cancellationToken)
        {
            var resultList = await _personService.GetByMonthBDAsync(month, cancellationToken);
            return StatusCode((int)HttpStatusCode.OK, resultList);
        }


        [HttpGet("Birthdays/ByDate/")]
        public async Task<IActionResult> GetTodayBDAsync(CancellationToken cancellationToken)
        {
            var resultList = await _personService.GetByDateAsync(DateTime.Now, null, cancellationToken);
            return StatusCode((int)HttpStatusCode.OK, resultList);
        }

        [HttpGet("Birthdays/ByDate/{includeDays:int}")]
        public async Task<IActionResult> GetTidayIncludeDaysBDAsync(int includeDays, CancellationToken cancellationToken)
        {
            var resultList = await _personService.GetByDateAsync(DateTime.Now, includeDays, cancellationToken);
            return StatusCode((int)HttpStatusCode.OK, resultList);
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] PersonRequest model, CancellationToken cancellationToken)
        {
            if (model.Date.Kind != DateTimeKind.Utc)
                model.Date= model.Date.ToUniversalTime();

            await _personService.CreateAsync(model, cancellationToken);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await _personService.DeletedAsync(id, cancellationToken);

            return StatusCode((int)HttpStatusCode.NoContent);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] PersonRequestWithId model, CancellationToken cancellationToken)
        {
            var updatedPersonResponse = await _personService.UpdateAsync(model, cancellationToken);
            return StatusCode((int)HttpStatusCode.Created, updatedPersonResponse);
        }
    }
}
