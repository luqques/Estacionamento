﻿using AutoMapper;
using Estacionamento.Fipe.Api.Dto;
using Estacionamento.Fipe.Api.Events;
using Estacionamento.Fipe.Api.FipeHttpClient;
using ItemService.RabbitMqClient;

namespace Estacionamento.Fipe.Api
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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            services.AddHttpClient<FipeServiceHttpClient>();
            services.AddHttpClient();
            services.AddSingleton<RabbitMqConsumer>();
            services.AddHostedService(sp => sp.GetRequiredService<RabbitMqConsumer>());

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddSingleton(new MapperConfiguration(config =>
            {
                //config.CreateMap<VeiculoDto, VeiculoEntity>();
                //config.CreateMap<VeiculoEntity, VeiculoDto>();
            }).CreateMapper());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowAll");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}