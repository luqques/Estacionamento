using AutoMapper;
using Estacionamento.Fipe.Api.Dto;
using Estacionamento.Fipe.Api.FipeHttpClient;

namespace Estacionamento.Fipe.Api.Events
{
    public class ProcessaEvento : IProcessaEvento
    {
        private readonly IMapper _mapper;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IHttpClientFactory _httpClientFactory;

        public ProcessaEvento(IMapper mapper, IServiceScopeFactory scopeFactory, IHttpClientFactory httpClientFactory)
        {
            _mapper = mapper;
            _scopeFactory = scopeFactory;
            _httpClientFactory = httpClientFactory;
        }

        public void ConsumirEvento(string mensagem)
        {
            using var scope = _scopeFactory.CreateScope();

            var tabelaFipeService = scope.ServiceProvider.GetRequiredService<IFipeServiceHttpClient>();

            tabelaFipeService.ConsultaTabelaFipeAsync(mensagem);
        }

        public void PublicarEvento(VeiculoDto mensagem)
        {
            throw new NotImplementedException();
        }
    }
}
