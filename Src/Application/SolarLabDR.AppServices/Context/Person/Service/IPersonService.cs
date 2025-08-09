using SolarLabDR.Contracts.Image;
using SolarLabDR.Contracts.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarLabDR.AppServices.Context.Person.Service
{
    public interface IPersonService
    {
        Task<PersonResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<PersonResponse>> GetAllAsync(CancellationToken cancellationToken);     
        Task<List<PersonResponse>> GetByMonthBDAsync(int moth, CancellationToken cancellationToken);
        Task<List<PersonResponse>> GetByDateAsync(DateTime date, int? includeDays, CancellationToken cancellationToken);
        Task<Guid> CreateAsync(PersonRequest request, CancellationToken cancellationToken);
        Task DeletedAsync(Guid id, CancellationToken cancellationToken);
    }
}
