using FluentValidation;
using WebApplicationApi.Models;

namespace DapperAPI.Validations
{
    public class ValidationsGrupoFamiliar : AbstractValidator<GrupoFamiliar>
    {
        public ValidationsGrupoFamiliar()
        {
            RuleFor(x => x.Nombres).NotEmpty().WithMessage("El campo {PropertyName} es requerido");
        }
    }
}
