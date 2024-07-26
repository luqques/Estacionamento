using AutoMapper;
using Estacionamento.Data.Context;
using Estacionamento.Data.Repository.Estacionamento;
using Estacionamento.Data.Repository.TabelaDePrecos;
using Estacionamento.Data.VeiculoRepository;
using Estacionamento.Domain.Dto;
using Estacionamento.Domain.Entities;
using Estacionamento.Service.Services.Estacionamento;
using Estacionamento.Service.Services.TabelaDePrecos;
using Estacionamento.Service.Services.Veiculo;
using Microsoft.EntityFrameworkCore;

namespace Estacionamento.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<MySqlContext>(options =>
            {
                var connection = Configuration["MySqlConnectionString"];
                var serverVersion = new MySqlServerVersion(new Version(8, 0, 36));

                options.UseMySql(connection, serverVersion);
            });

            services.AddScoped<IEstacionamentoRepository, EstacionamentoRepository>();
            services.AddScoped<IEstacionamentoService, EstacionamentoService>();

            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IVeiculoService, VeiculoService>();

            services.AddScoped<ITabelaDePrecosRepository, TabelaDePrecosRepository>();
            services.AddScoped<ITabelaDePrecosService, TabelaDePrecosService>();

            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<VeiculoDto, VeiculoEntity>();
                config.CreateMap<VeiculoEntity, VeiculoDto>();

                config.CreateMap<RegistroEstacionamentoDto, RegistroEstacionamentoEntity>();
                config.CreateMap<RegistroEstacionamentoEntity, RegistroEstacionamentoDto>();

                config.CreateMap<TabelaDePrecosDto, TabelaDePrecosEntity>();
                config.CreateMap<TabelaDePrecosEntity, TabelaDePrecosDto>();
            }).CreateMapper());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
