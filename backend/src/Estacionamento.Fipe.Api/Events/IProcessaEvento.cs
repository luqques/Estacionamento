using Estacionamento.Fipe.Api.Dto;

namespace Estacionamento.Fipe.Api.Events
{
    public interface IProcessaEvento
    {
        void ConsumirEvento(string mensagem);
        void PublicarEvento(VeiculoDto mensagem);
    }
}
