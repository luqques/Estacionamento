using Estacionamento.Domain.Entities;
using FluentValidation;

namespace Estacionamento.Service.Validators
{
    public class VeiculoValidator : AbstractValidator<Veiculo>
    {
        public VeiculoValidator()
        {
            RuleFor(c => c.Placa)
                .NotEmpty().WithMessage("Por favor insira a Placa do veículo.")
                .NotNull().WithMessage("Por favor insira a Placa do veículo.");

            RuleFor(c => c.NomeProprietario)
                .NotEmpty().WithMessage("Por favor insira o Nome do Proprietário do veículo.")
                .NotNull().WithMessage("Por favor insira o Nome do Proprietário do veículo.");

            RuleFor(c => c.Modelo)
                .NotEmpty().WithMessage("Por favor insira o Modelo do veículo.")
                .NotNull().WithMessage("Por favor insira o Modelo do veículo.");
        }
    }
}
