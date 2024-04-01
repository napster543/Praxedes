using DapperAPI.Model;
using FluentValidation;
using WebApplicationApi.Models;

namespace DapperAPI.Validations
{
    public class ValidationsComment : AbstractValidator<Comments>
    {
        public ValidationsComment()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("El campo {PropertyName} es requerido");
            RuleFor(x => x.postId).NotEmpty().WithMessage("El campo {PropertyName} es requerido");
            RuleFor(x => x.name).NotEmpty().WithMessage("El campo {PropertyName} es requerido");
            RuleFor(x => x.email).NotEmpty().WithMessage("El campo {PropertyName} es requerido");
            RuleFor(x => x.body).NotEmpty().WithMessage("El campo {PropertyName} es requerido");
        }
    }
}
