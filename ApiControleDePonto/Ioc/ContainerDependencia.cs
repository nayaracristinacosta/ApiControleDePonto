using ApiControleDePonto.Repositories.Repositorio;
using ApiControleDePonto.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ApiControleDePonto.Ioc
{
    public class ContainerDependencia
    {
        public static void RegistrarServicos(IServiceCollection services)
        {
            //repositorios
            services.AddScoped<FuncionarioRepositorio, FuncionarioRepositorio>();
            services.AddScoped<CargoRepositorio, CargoRepositorio>();
            services.AddScoped<EquipeRepositorio, EquipeRepositorio>();
            services.AddScoped<LiderancaRepositorio, LiderancaRepositorio>();
            services.AddScoped<PontoRepositorio, PontoRepositorio>();

            //services
            services.AddScoped<FuncionarioService, FuncionarioService>();
            services.AddScoped<CargoService, CargoService>();
            services.AddScoped<EquipeService, EquipeService>();
            services.AddScoped<LiderancaService, LiderancaService>();
            services.AddScoped<PontoService, PontoService>();
            services.AddScoped<AutorizacaoService, AutorizacaoService>();
        }
    }
}