using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using SolarLabDR.AppServices.Context.Image.Repository;
using SolarLabDR.AppServices.Context.Image.Service;
using SolarLabDR.AppServices.Context.Person.Repository;
using SolarLabDR.AppServices.Context.Person.Service;
using SolarLabDR.DataAccess.Repository;
using SolarLabDR.Infrastructure.Repository;
using SolarLabDR.MapProfile;

namespace SolarLabDR.ComponentRegistrator
{
    public static class ComponentRegistrator
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));

            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IPersonService, PersonService>();


            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();


            return services;
        }

        private static MapperConfiguration GetMapperConfiguration()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ImageProfile>();
                cfg.AddProfile<PersonProfile>();
            }, new NullLoggerFactory());

            configuration.AssertConfigurationIsValid();
            return configuration;
        }
    }
}
