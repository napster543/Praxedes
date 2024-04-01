using DapperAPI.Model;
using FluentValidation;
using WebApplicationApi.Models;

namespace DapperAPI.Validations
{
    public class ValidationsPost : AbstractValidator<Post>
    {
        public ValidationsPost()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("El campo {PropertyName} es requerido");
            RuleFor(x => x.userId).NotEmpty().WithMessage("El campo {PropertyName} es requerido");
            RuleFor(x => x.title).NotEmpty().WithMessage("El campo {PropertyName} es requerido");
            RuleFor(x => x.body).NotEmpty().WithMessage("El campo {PropertyName} es requerido");
        }
    }
}
