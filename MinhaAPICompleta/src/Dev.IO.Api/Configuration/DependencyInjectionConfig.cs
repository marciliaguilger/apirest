using Dev.IO.Business.Interfaces;
using Dev.IO.Business.Notifications;
using Dev.IO.Business.Services;
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
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();


            services.AddScoped<INotificator, Notificator>();
            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            
            return services;
        }
    }
}
