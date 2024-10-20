﻿using Common.Application.Validation;
using FluentValidation;

namespace Cms.Application.Categories.Create;

internal partial class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(r => r.Title)
            .NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));

        RuleFor(r => r.Slug)
          .NotNull().NotEmpty().WithMessage(ValidationMessages.required("Slug"));
    }
}