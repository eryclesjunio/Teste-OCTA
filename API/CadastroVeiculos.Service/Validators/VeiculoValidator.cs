using CadastroVeiculos.Domain.Entities;
using FluentValidation;

namespace CadastroVeiculos.Service.Validators
{
    public class VeiculoValidator : AbstractValidator<Veiculo>
    {
        public VeiculoValidator()
        {
            RuleFor(c => c.Marca)
                .NotEmpty().WithMessage("Por favor, preencha a marca.")
                .NotNull().WithMessage("Por favor, preencha a marca.");

            RuleFor(c => c.Placa)
                .NotEmpty().WithMessage("Por favor, preencha a placa.")
                .NotNull().WithMessage("Por favor, preencha a placa.");

            RuleFor(c => c.CpfCnpj)
                .NotEmpty().WithMessage("Por favor, preencha o proprietario.")
                .NotNull().WithMessage("Por favor, preencha o proprietario.");
        }
    }
}
