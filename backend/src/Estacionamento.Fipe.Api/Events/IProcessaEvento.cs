namespace Estacionamento.Fipe.Api.Events
{
    public interface IProcessaEvento
    {
        void ProcessarEvento(string mensagem);
    }
}
