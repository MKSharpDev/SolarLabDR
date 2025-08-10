using AutoMapper;
using SolarLabDR.AppServices.Context.Image.Repository;
using SolarLabDR.AppServices.Context.Person.Repository;
using SolarLabDR.Contracts.Image;
using SolarLabDR.Contracts.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarLabDR.AppServices.Context.Person.Service
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAsync(PersonRequest personRequest, CancellationToken cancellationToken)
        {
            var personDto = _mapper.Map<PersonDto>(personRequest);
            var id = await _personRepository.CreateAsync(personDto, cancellationToken);

            return id;
        }

        public async Task DeletedAsync(Guid id, CancellationToken cancellationToken)
        {
            await _personRepository.DeleteAsync(id, cancellationToken);
        }

        public async Task<PersonResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var personDto = await _personRepository.GetByIdAsync(id, cancellationToken);
            var personResponse = _mapper.Map<PersonResponse>(personDto);

            return personResponse;
        }

        public async Task<List<PersonResponse>> GetAllAsync(CancellationToken cancellationToken)
        {
            var personList = await _personRepository.GetAllAsync(cancellationToken);

            return personList.Select(i => _mapper.Map<PersonResponse>(i)).ToList();
        }

        public async Task<List<PersonResponse>> GetByMonthBDAsync(int moth, CancellationToken cancellationToken)
        {
            var personList = await _personRepository.GetByMonthBDAsync(moth, cancellationToken);
            return personList.Select(i => _mapper.Map<PersonResponse>(i)).ToList();
        }

        public async Task<List<PersonResponse>> GetByDateAsync(DateTime date, int? includeDays, CancellationToken cancellationToken)
        {
            var personList = await _personRepository.GetByDateAsync(date, includeDays, cancellationToken);
            return personList.Select(i => _mapper.Map<PersonResponse>(i)).ToList();
        }
    }
}
