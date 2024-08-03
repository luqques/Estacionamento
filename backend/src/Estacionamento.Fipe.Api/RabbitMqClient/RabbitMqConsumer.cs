using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Estacionamento.Fipe.Api.Events;
using Estacionamento.Fipe.Api.FipeHttpClient;

namespace ItemService.RabbitMqClient
{
    public class RabbitMqConsumer : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IProcessaEvento _processaEvento;
        private readonly IFipeServiceHttpClient _fipeServiceClient;
        private readonly string _nomeDaFila;

        public RabbitMqConsumer(IConfiguration configuration, IProcessaEvento processaEvento, IFipeServiceHttpClient fipeServiceClient)
        {
            _configuration = configuration;

            _connection = new ConnectionFactory()
            {
                HostName = _configuration["RabbitMQ:Host"],
                Port = Int32.Parse(_configuration["RabbitMQ:Port"])
            }.CreateConnection();
            _channel = _connection.CreateModel();
            
            _channel.QueueDeclare(queue: "consulta_fipe", durable: false, exclusive: false, autoDelete: false, arguments: null);
            _channel.QueueDeclare(queue: "resposta_fipe", durable: false, exclusive: false, autoDelete: false, arguments: null);

            _channel.ExchangeDeclare(exchange: "trigger",
                                     type: ExchangeType.Fanout);

            _nomeDaFila = _channel.QueueDeclare().QueueName;

            _channel.QueueBind(queue: _nomeDaFila,
                               exchange: "trigger",
                               routingKey: "");

            _processaEvento = processaEvento;
            _fipeServiceClient = fipeServiceClient;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            if (await _fipeServiceClient.HealthCheckSiteFipeAsync())
                Console.WriteLine("Site da Fipe está fora do ar.");

            EventingBasicConsumer? consumidor = new EventingBasicConsumer(_channel);

            consumidor.Received += async (ModuleHandle, ea) =>
            {
                ReadOnlyMemory<byte> body = ea.Body;
                string mensagem = Encoding.UTF8.GetString(body.ToArray());

                _processaEvento.ConsumirEvento(mensagem);
            };

            _channel.BasicConsume(queue: _nomeDaFila,
                                  autoAck: true,
                                  consumer: consumidor);

            return Task.CompletedTask;
        }
    }
}
