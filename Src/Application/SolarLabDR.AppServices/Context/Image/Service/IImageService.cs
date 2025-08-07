using SolarLabDR.Contracts.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarLabDR.AppServices.Context.Image.Service
{
    public interface IImageService
    {
        Task<ImageResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<ImageResponse>> GetByUserIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Guid> CreateAsync(ImageRequest request, CancellationToken cancellationToken);
        Task DeletedAsync(Guid id, CancellationToken cancellationToken);
    }
}
