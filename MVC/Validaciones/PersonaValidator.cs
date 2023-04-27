using FluentValidation;
using MVC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Validaciones
{
    public class PersonaValidator : AbstractValidator<Persona>
    {
        public PersonaValidator()
        {
            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("El nombre no puede estar vacio")
                .Length(3, 20).WithMessage("El nombre debe tener entre 3 y 20 caracteres");
        }
    }
}
