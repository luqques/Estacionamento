using Estacionamento.Domain.Entities;
using Estacionamento.Service.Services.TabelaDePrecos;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Api.Controllers
{
    [Route("api/v1/tabelaDePrecos")]
    [ApiController]
    public class TabelaDePrecosController : ControllerBase
    {
        private readonly ITabelaDePrecosService _tabelaDePrecosService;

        public TabelaDePrecosController(ITabelaDePrecosService tabelaDePrecosService)
        {
            _tabelaDePrecosService = tabelaDePrecosService;
        }

        [HttpPost("alterar-preco")]
        public async Task<ActionResult<TabelaDePrecosEntity>> AlterarPrecoHora(decimal precoHora)
        {
            if (precoHora <= 0m)
                return BadRequest("Por favor, insira um valor maior que zero.");

            var tabelaDePrecos = await _tabelaDePrecosService.AlterarPrecoHora(precoHora);

            return Ok(new { message = "Preços alterados com sucesso!" });
        }
    }
}
