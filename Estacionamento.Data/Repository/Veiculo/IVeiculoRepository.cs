﻿using Estacionamento.Domain.Dto;

namespace Estacionamento.Data.VeiculoRepository
{
    public interface IVeiculoRepository
    {
        Task<VeiculoDto> CadastrarVeiculo(VeiculoDto veiculoDto);

        Task<bool> ExisteVeiculoPorPlaca(string placaVeiculo);

        Task<VeiculoDto> AtualizarVeiculo(VeiculoDto veiculoDto);
    }
}