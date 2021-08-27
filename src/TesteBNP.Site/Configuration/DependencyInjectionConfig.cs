using Microsoft.Extensions.DependencyInjection;
using TesteBNP.Negocios.Interfaces;
using TesteBNP.Dados;
using TesteBNP.Negocios.Interfaces.Repositorio;
using TesteBNP.Dados.Repositorio;
using TesteBNP.Negocios.Interfaces.Servicos;
using TesteBNP.Negocios.Servicos;

namespace TesteBNP.Site.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IConexao, Conexao>();
            services.AddScoped<IMovimentoManualRepositorio, MovimentoManualRepositorio>();
            services.AddScoped<IProdutoCosifRepositorio, ProdutoCosifRepositorio>();
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();

            services.AddScoped<IMovimentoManualServico, MovimentoManualServico>();
            services.AddScoped<IProdutoCosifServico, ProdutoCosifServico>();
            services.AddScoped<IProdutoServico, ProdutoServico>();

            return services;
        }
    }
}
