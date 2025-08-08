using SolarLabDR.AppServices.BaseRepository;
using SolarLabDR.Contracts.Person;

namespace SolarLabDR.AppServices.Context.Person.Repository
{
    public interface IPersonRepository : IRepository<PersonDto>
    {
        Task<List<PersonDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<List<PersonDto>> GetByMonthBDAsync(int moth, CancellationToken cancellationToken);       
    }
}
