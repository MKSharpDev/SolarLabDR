using SolarLabDR.AppServices.BaseRepository;
using SolarLabDR.Contracts.Image;

namespace SolarLabDR.AppServices.Context.Image.Repository
{
    public interface IImageRepository : IRepository<ImageDto>
    {
        Task<List<ImageDto>> GetByUserIdAsync(Guid Id, CancellationToken cancellationToken);
    }
}
