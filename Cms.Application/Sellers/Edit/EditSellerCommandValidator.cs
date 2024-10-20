using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Cms.Application.Sellers.Edit;

public class EditSellerCommandValidator : AbstractValidator<EditSellerCommand>
{
    public EditSellerCommandValidator()
    {
        RuleFor(r => r.CmsName)
            .NotEmpty().WithMessage(ValidationMessages.required("نام فروشگاه"));

        RuleFor(r => r.CmsName)
            .NotEmpty().WithMessage(ValidationMessages.required("کدملی"))
            .ValidNationalId();
    }
}