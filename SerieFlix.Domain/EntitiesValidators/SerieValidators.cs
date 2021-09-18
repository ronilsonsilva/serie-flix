using FluentValidation;
using SerieFlix.Domain.Entities;
using System;

namespace SerieFlix.Domain.EntitiesValidators
{

    public class SerieValidators : BaseValidator<Serie>
    {
        public SerieValidators()
        {
            RuleFor(x => x.Ano).NotNull().WithMessage("Ano deve ser preenchido")
                .GreaterThan(0).WithMessage("Ano invalido")
                .LessThan(DateTime.Now.Year).WithMessage("Ano inválido");

            RuleFor(x => x.Titulo).NotNull().WithMessage("Titulo deve ser preenchido.")
                .NotEmpty().WithMessage("Titulo deve ser preenchido.")
                .MaximumLength(512).WithMessage("Título deve ter no máximo 512 caracteres.");
        }
    }
}
