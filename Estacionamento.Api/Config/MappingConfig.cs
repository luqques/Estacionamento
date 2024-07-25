using AutoMapper;
using Estacionamento.Domain.Dto;
using Estacionamento.Domain.Entities;

namespace Estacionamento.Api.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<VeiculoDto, VeiculoEntity>();
                config.CreateMap<VeiculoEntity, VeiculoDto>();
            });

            return mappingConfig;
        }
    }
}
