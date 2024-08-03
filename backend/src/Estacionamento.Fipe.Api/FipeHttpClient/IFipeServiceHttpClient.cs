using Estacionamento.Fipe.Api.Dto;

namespace Estacionamento.Fipe.Api.FipeHttpClient
{
    public interface IFipeServiceHttpClient
    {
        public Task<bool> HealthCheckSiteFipeAsync();
        public Task<VeiculoDto> ConsultaTabelaFipeAsync(string mensagem);

    }
}
