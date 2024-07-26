using Estacionamento.Domain.Dto;
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
        public async Task<ActionResult<VeiculoDto>> CadastrarVeiculo(decimal precoHora)
        {
            if (precoHora <= 0m)
                return BadRequest("Não é possivel cadastrar um preço zerado.");

            var veiculo = await _tabelaDePrecosService.AlterarPrecoHora(precoHora);

            return Ok("Preço cadastrado com sucesso!" + veiculo);
        }
    }
}
