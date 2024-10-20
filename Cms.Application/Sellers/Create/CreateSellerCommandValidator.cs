using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Cms.Application.Sellers.Create;

public class CreateSellerCommandValidator : AbstractValidator<CreateSellerCommand>
{
    public CreateSellerCommandValidator()
    {
        RuleFor(r => r.CmsName)
            .NotEmpty().WithMessage(ValidationMessages.required("نام فروشگاه"));

        RuleFor(r => r.CmsName)
            .NotEmpty().WithMessage(ValidationMessages.required("کدملی"))
            .ValidNationalId();
    }
}