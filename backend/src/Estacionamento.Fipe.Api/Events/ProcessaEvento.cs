using AutoMapper;

namespace Estacionamento.Fipe.Api.Events
{
    public class ProcessaEvento : IProcessaEvento
    {
        private readonly IMapper _mapper;
        private readonly IServiceScopeFactory _scopeFactory;

        public ProcessaEvento(IMapper mapper, IServiceScopeFactory scopeFactory)
        {
            _mapper = mapper;
            _scopeFactory = scopeFactory;
        }

        public void ProcessarEvento(string mensagem)
        {
            using var scope = _scopeFactory.CreateScope();

            //var tabelaFipeService = scope.ServiceProvider.GetRequiredService<ITabelaFipeService>();

            throw new NotImplementedException();
        }
    }
}
