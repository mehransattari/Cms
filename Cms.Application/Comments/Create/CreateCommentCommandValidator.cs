﻿using Common.Application.Validation;
using FluentValidation;

namespace Cms.Application.Comments.Create
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(r => r.Text)
                .NotNull()
                .MinimumLength(5).WithMessage(ValidationMessages.minLength("متن نظر", 5));
        }
    }
}