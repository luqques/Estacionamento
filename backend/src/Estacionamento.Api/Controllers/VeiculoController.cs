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
            try
            {
                if (veiculoDto is null)
                    return BadRequest(new { message = "Por favor, preencha as informações do veículo." });

                var veiculo = await _veiculoService.CadastrarOuAtualizarVeiculo(veiculoDto);

                return Ok(new { message = "Veículo cadastrado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("remover/{placaVeiculo}")]
        public async Task<ActionResult<bool>> SaidaVeiculo(string placaVeiculo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(placaVeiculo))
                    return BadRequest(new { message = "Por favor, informe a placa do veículo." });

                bool veiculo = await _veiculoService.RemoverVeiculo(placaVeiculo);

                if (!veiculo)
                    return NotFound("Veículo não encontrado.");

                return Ok(new { message = "Veículo removido do banco de dados com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
