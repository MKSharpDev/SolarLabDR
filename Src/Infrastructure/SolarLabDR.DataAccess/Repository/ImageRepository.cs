using SolarLabDR.AppServices.Context.Image.Repository;
using SolarLabDR.Contracts.Image;
using SolarLabDR.Domain;
using SolarLabDR.Infrastructure.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace SolarLabDR.DataAccess.Repository
{
    public class ImageRepository : IImageRepository
    {
        private readonly IRepository<Image, DrDbContext> _repository;
        private readonly IMapper _mapper;

        public ImageRepository(IRepository<Image, DrDbContext> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAsync(ImageDto imageDto, CancellationToken cancellationToken)
        {
            var image = _mapper.Map<Image>(imageDto);
            await _repository.AddAsync(image, cancellationToken);

            return image.Id;
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(id, cancellationToken);
        }

        public async Task<ImageDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var image = await _repository.GetByIdAsync(id, cancellationToken);

            return _mapper.Map<ImageDto>(image);
        }

        public async Task<List<ImageDto>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            var images = await _repository.GetByPredicate(i => i.PersonId == userId)              
                .ToListAsync(cancellationToken);

            return images?.Select(_mapper.Map<ImageDto>).ToList() ?? new List<ImageDto>(); 
        }

        public Task<ImageDto> UpdateAsync(ImageDto tDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
