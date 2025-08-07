using AutoMapper;
using SolarLabDR.AppServices.Context.Image.Repository;
using SolarLabDR.Contracts.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarLabDR.AppServices.Context.Image.Service
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;

        public ImageService(IImageRepository imageRepository, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAsync(ImageRequest imageRequest, CancellationToken cancellationToken)
        {
            var imageDto = _mapper.Map<ImageDto>(imageRequest);
            var id = await _imageRepository.CreateAsync(imageDto, cancellationToken);
            return id;
        }

        public async Task DeletedAsync(Guid id, CancellationToken cancellationToken)
        {
            await _imageRepository.DeleteAsync(id, cancellationToken);
        }

        public async Task<ImageResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var imageDto = await _imageRepository.GetByIdAsync(id, cancellationToken);
            var ImageResponse = _mapper.Map<ImageResponse>(imageDto);
            return ImageResponse;
        }

        public async Task<List<ImageResponse>> GetByUserIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var imageList = await _imageRepository.GetByUserIdAsync(id, cancellationToken);
            return imageList.Select(i => _mapper.Map<ImageResponse>(i)).ToList();
        }
    }
}
