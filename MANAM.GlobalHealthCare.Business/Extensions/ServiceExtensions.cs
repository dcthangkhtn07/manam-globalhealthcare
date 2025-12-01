using MANAM.GlobalHealthCare.Business.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MANAM.GlobalHealthCare.Business.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddTransient<ICompanyProfileBusiness, CompanyProfileBusiness>();
            services.AddTransient<IMedicalEntityBusiness, MedicalEntityBusiness>();
            services.AddTransient<IIdentityBusiness, IdentityBusiness>();

            return services;
        }
    }
}
