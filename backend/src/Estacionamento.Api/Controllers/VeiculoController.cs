using Estacionamento.Domain.Dto;
using Estacionamento.Domain.Entities;
using Estacionamento.Service.Services.Estacionamento;
using Estacionamento.Service.Services.Veiculo;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Api.Controllers
{
    [Route("api/v1/veiculo")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private IVeiculoService _veiculoService;

        public VeiculoController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService ?? throw new ArgumentNullException(nameof(veiculoService));
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult<VeiculoEntity>> CadastrarVeiculo([FromBody] VeiculoDto veiculoDto)
        {
            if (veiculoDto is null)
                return BadRequest();

            var veiculo = await _veiculoService.CadastrarOuAtualizarVeiculo(veiculoDto);

            return Ok(veiculo);
        }

        [HttpDelete("remover/{veiculoId}")]
        public async Task<ActionResult<bool>> SaidaVeiculo(int id)
        {
            if (id == 0)
                return BadRequest();

            bool veiculo = await _veiculoService.RemoverVeiculo(id);

            if (veiculo)
                return NotFound();

            return Ok(veiculo);
        }
    }
}
