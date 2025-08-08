using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SolarLabDR.AppServices.Context.Image.Repository;
using SolarLabDR.AppServices.Context.Person.Repository;
using SolarLabDR.Contracts.Image;
using SolarLabDR.Contracts.Person;
using SolarLabDR.Domain;
using SolarLabDR.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SolarLabDR.DataAccess.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IRepository<Person, DrDbContext> _repository;
        private readonly IMapper _mapper;

        public PersonRepository(IRepository<Person, DrDbContext> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Guid> CreateAsync(PersonDto personDto, CancellationToken cancellationToken)
        {
            var person = _mapper.Map<Person>(personDto);
            await _repository.AddAsync(person, cancellationToken);

            return person.Id;
        }

        public async Task DeleteAsync(Guid Id, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(Id, cancellationToken);
        }

        public async Task<List<PersonDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var persons = await _repository.GetAll().ToListAsync(cancellationToken);

            return persons?.Select(_mapper.Map<PersonDto>).ToList() ?? new List<PersonDto>();
        }

        public async Task<PersonDto> GetByIdAsync(Guid Id, CancellationToken cancellationToken)
        {
            var person = await _repository.GetByIdAsync(Id, cancellationToken);

            return _mapper.Map<PersonDto>(person);
        }

        public async Task<PersonDto> UpdateAsync(PersonDto personDto, CancellationToken cancellationToken)
        {
            var person = _mapper.Map<Person>(personDto);
            await _repository.UpdateAsync(person, cancellationToken);
            var advertResult = await _repository.GetByIdAsync(person.Id, cancellationToken);

            return _mapper.Map<PersonDto>(advertResult);
        }

        public async Task<List<PersonDto>> GetByDateAsync(DateTime date, CancellationToken cancellationToken)
        {
            var persons = await _repository.GetByPredicate(p => p.Date.DayOfYear == date.DayOfYear).ToListAsync(cancellationToken);

            return persons?.Select(_mapper.Map<PersonDto>).ToList() ?? new List<PersonDto>();
        }

        public async Task<List<PersonDto>> GetByMonthBDAsync(int moth, CancellationToken cancellationToken)
        {
            var persons = await _repository.GetByPredicate(p => p.Date.Month == moth).ToListAsync(cancellationToken);

            return persons?.Select(_mapper.Map<PersonDto>).ToList() ?? new List<PersonDto>(); 
        }
    }
}
