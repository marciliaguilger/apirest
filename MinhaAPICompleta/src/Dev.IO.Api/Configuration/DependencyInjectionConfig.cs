using Dev.IO.Business.Interfaces;
using Dev.IO.Data.Context;
using Dev.IO.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Dev.IO.Api.Configuration
{
    public static class DependencyInjectionConfig 
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            
            return services;
        }
    }
}
