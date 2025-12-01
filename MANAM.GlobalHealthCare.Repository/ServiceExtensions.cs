using MANAM.GlobalHealthCare.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MANAM.GlobalHealthCare.Repository
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
