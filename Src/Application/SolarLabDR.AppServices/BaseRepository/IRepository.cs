using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarLabDR.AppServices.BaseRepository
{
    public interface IRepository<TDto> where TDto : class
    {
        Task<Guid> CreateAsync(TDto tDto, CancellationToken cancellationToken);
        Task DeleteAsync(Guid Id, CancellationToken cancellationToken);
        Task<TDto> UpdateAsync(TDto tDto, CancellationToken cancellationToken);
        Task<TDto> GetByIdAsync(Guid Id, CancellationToken cancellationToken);
    }
}
