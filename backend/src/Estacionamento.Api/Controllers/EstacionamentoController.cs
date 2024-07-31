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
                return BadRequest(new { message = "Insira os dados referente ao veículo." });

            try
            {
                var veiculo = await _estacionamentoService.RegistrarEntradaDeVeiculo(veiculoDto);

                return Ok(new { message = "Entrada do veículo registrada com sucesso!" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("registrar-saida/{placa}")]
        public async Task<ActionResult<RegistroEstacionamentoDetalhadoDto>> SaidaVeiculo(string placa)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(placa))
                    return BadRequest(new { message = "Por favor, insira a placa de um veículo." });

                var registroRemovido = await _estacionamentoService.RegistrarSaidaDeVeiculo(placa.ToUpper());

                if (registroRemovido is null)
                    return NotFound(new { message = "Este veículo não se encontra no estacionamento." });

                return Ok(registroRemovido);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("listar-registros")]
        public async Task<ActionResult<IEnumerable<RegistroEstacionamentoDetalhadoDto>>> ListarRegistros(bool registrosAtivos)
        {
            try
            {
                var registros = await _estacionamentoService.ListarRegistrosAtivosDetalhado(registrosAtivos);
                return Ok(registros);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
