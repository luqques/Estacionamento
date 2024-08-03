using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Estacionamento.Fipe.Api.Events;

namespace ItemService.RabbitMqClient
{
    public class RabbitMqSubscriber : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IProcessaEvento _processaEvento;
        private readonly string _nomeDaFila;

        public RabbitMqSubscriber(IConfiguration configuration, IProcessaEvento processaEvento)
        {
            _configuration = configuration;

            _connection = new ConnectionFactory()
            {
                HostName = _configuration["RabbitMQ:Host"],
                Port = Int32.Parse(_configuration["RabbitMQ:Port"])
            }.CreateConnection();

            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare(exchange: "trigger",
                                     type: ExchangeType.Fanout);

            _nomeDaFila = _channel.QueueDeclare().QueueName;

            _channel.QueueBind(queue: _nomeDaFila,
                               exchange: "trigger",
                               routingKey: "");

            _processaEvento = processaEvento;
        }

        protected override Task ExecuteAsync(CancellationToken cancellationToken)
        {
            EventingBasicConsumer? consumidor = new EventingBasicConsumer(_channel);

            consumidor.Received += (ModuleHandle, ea) =>
            {
                ReadOnlyMemory<byte> body = ea.Body;
                string mensagem = Encoding.UTF8.GetString(body.ToArray());
                _processaEvento.ProcessarEvento(mensagem);
            };

            _channel.BasicConsume(queue: _nomeDaFila,
                                  autoAck: true,
                                  consumer: consumidor);

            return Task.CompletedTask;
        }
    }
}
