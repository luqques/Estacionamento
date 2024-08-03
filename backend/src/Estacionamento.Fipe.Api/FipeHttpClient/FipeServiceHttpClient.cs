
using Estacionamento.Fipe.Api.Dto;
using System.Net.Http;
using System.Text;

namespace Estacionamento.Fipe.Api.FipeHttpClient
{
    public class FipeServiceHttpClient : IFipeServiceHttpClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;
        private readonly string _fipeUrl;

        public FipeServiceHttpClient(HttpClient httpClient, string fipeUrl, IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClient;
            _fipeUrl = fipeUrl;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> HealthCheckSiteFipeAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(_fipeUrl);
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<VeiculoDto> ConsultaTabelaFipeAsync(string mensagem)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient();
                var request = new HttpRequestMessage(HttpMethod.Post, "https://veiculos.fipe.org.br/api/veiculos//ConsultarValorComTodosParametros")
                {
                    Headers =
                    {
                        { "accept", "application/json, text/javascript, */*; q=0.01" },
                        { "accept-language", "pt-BR,pt;q=0.9,en-US;q=0.8,en;q=0.7,ar;q=0.6" },
                        { "origin", "https://veiculos.fipe.org.br" },
                        { "priority", "u=0, i" },
                        { "referer", "https://veiculos.fipe.org.br/" },
                        { "sec-ch-ua", "\"Not)A;Brand\";v=\"99\", \"Google Chrome\";v=\"127\", \"Chromium\";v=\"127\"" },
                        { "sec-ch-ua-mobile", "?0" },
                        { "sec-ch-ua-platform", "\"Windows\"" },
                        { "sec-fetch-dest", "empty" },
                        { "sec-fetch-mode", "cors" },
                        { "sec-fetch-site", "same-origin" },
                        { "user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/127.0.0.0 Safari/537.36" },
                        { "x-requested-with", "XMLHttpRequest" }
                    },
                    Content = new StringContent("codigoTabelaReferencia=312&codigoMarca=21&codigoModelo=634&codigoTipoVeiculo=1&anoModelo=1997&codigoTipoCombustivel=1&tipoVeiculo=carro&modeloCodigoExterno=&tipoConsulta=tradicional", Encoding.UTF8, "application/x-www-form-urlencoded")
                };

                var response = await httpClient.SendAsync(request);

                
            }
            catch (Exception)
            {

            }
        }
    }
}
