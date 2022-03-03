using CadastroVeiculos.Domain.Entities;
using FluentValidation;

namespace CadastroVeiculos.Service.Validators
{
    public class ProprietarioValidator : AbstractValidator<Proprietario>
    {
        public ProprietarioValidator()
        {
            RuleFor(c => c.CpfCnpj)
                .NotEmpty().WithMessage("Por favor, preencha o CPF/CNPJ.")
                .NotNull().WithMessage("Por favor, preencha o CPF/CNPJ.");

            RuleFor(c => c.Endereco)
                .NotEmpty().WithMessage("Por favor, preencha o endereço.")
                .NotNull().WithMessage("Por favor, preencha o endereço.");

            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Por favor, preencha o nome.")
                .NotNull().WithMessage("Por favor, preencha o nome.");
        }
    }
}
