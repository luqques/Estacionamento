using Estacionamento.Data.Dto;
using Estacionamento.Domain.Dto;
using Estacionamento.Service.Services.Estacionamento;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EstacionamentoController : ControllerBase
    {
        private IEstacionamentoService _estacionamentoService;

        public EstacionamentoController(IEstacionamentoService estacionamentoService)
        {
            _estacionamentoService = estacionamentoService ?? throw new ArgumentNullException(nameof(estacionamentoService));
        }

        [HttpPost]
        public async Task<ActionResult<RegistroEstacionamentoDto>> EntradaVeiculo([FromBody] VeiculoDto veiculoDto)
        {
            if (veiculoDto is null)
                return BadRequest();

            var veiculo = await _estacionamentoService.RegistrarEntradaDeVeiculo(veiculoDto);

            return Ok(veiculo);
        }
    }
}
