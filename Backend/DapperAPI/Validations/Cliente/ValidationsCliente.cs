using FluentValidation;
using WebApplicationApi.Models;

namespace DapperAPI.Validations
{
    public class ValidationsCliente : AbstractValidator<Cliente>
    {
        public ValidationsCliente()
        {
            RuleFor(x => x.Nombres).NotEmpty().WithMessage("El campo {PropertyName} es requerido");
        }
    }
}
