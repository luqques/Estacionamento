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

        [HttpPost("registrar-entrada")]
        public async Task<ActionResult<VeiculoDto>> EntradaVeiculo([FromBody] VeiculoDto veiculoDto)
        {
            if (veiculoDto is null)
                return BadRequest();

            var veiculo = await _estacionamentoService.RegistrarEntradaDeVeiculo(veiculoDto);

            return Ok(new { message = "Registrado entrada do veículo com sucesso!"});
        }

        [HttpDelete("registrar-saida/{veiculoId}")]
        public async Task<ActionResult<bool>> SaidaVeiculo(int veiculoId)
        {
            if (veiculoId == 0)
                return BadRequest();

            bool veiculoRemovido = await _estacionamentoService.RegistrarSaidaDeVeiculo(veiculoId);

            if (!veiculoRemovido) //TODO: Corrigir chegagem se o veículo está ou não no estacionamento, valdando pela DataHoraSaida do registro
                return NotFound(new { message = "O veículo não se encontra no estacionamento." });

            return Ok(new { message = "Registrado saída do veículo com sucesso!" });
        }

        [HttpGet("listar-registros")]
        public async Task<ActionResult<IEnumerable<RegistroEstacionamentoDetalhadoDto>>> ListarRegistros()
        {
            var registros = await _estacionamentoService.ListarRegistrosDetalhado();
            return Ok(registros);
        }
    }
}
