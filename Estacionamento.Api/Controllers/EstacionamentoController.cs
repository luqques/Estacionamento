using Estacionamento.Domain.Dto;
using Estacionamento.Service.Services.Estacionamento;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Api.Controllers
{
    [Route("api/v1/registroEstacionamento")]
    [ApiController]
    public class EstacionamentoController : ControllerBase
    {
        private IEstacionamentoService _estacionamentoService;

        public EstacionamentoController(IEstacionamentoService estacionamentoService)
        {
            _estacionamentoService = estacionamentoService ?? throw new ArgumentNullException(nameof(estacionamentoService));
        }

        [HttpPost("registrarEntrada")]
        public async Task<ActionResult<RegistroEstacionamentoDto>> EntradaVeiculo([FromBody] VeiculoDto veiculoDto)
        {
            if (veiculoDto is null)
                return BadRequest();

            var veiculo = await _estacionamentoService.RegistrarEntradaDeVeiculo(veiculoDto);

            return Ok(veiculo);
        }

        [HttpDelete("registrarSaida/{veiculoId}")]
        public async Task<ActionResult<bool>> SaidaVeiculo(int veiculoId)
        {
            if (veiculoId == 0)
                return BadRequest();

            bool veiculo = await _estacionamentoService.RegistrarSaidaDeVeiculo(veiculoId);

            if (veiculo)
                return NotFound();

            return Ok(veiculo);
        }
    }
}
