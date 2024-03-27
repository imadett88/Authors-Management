using FluentValidation;
using Post.Application.Authors.Commands.UpdateAuthor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Application.Authors.Validation
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(v => v.AuthorName)
                .NotNull()
                .NotEmpty().WithMessage("don't miss the author name")
                .MaximumLength(70);

            RuleFor(v => v.Description)
                .NotNull()
                .NotEmpty().WithMessage("don't miss the description");

            RuleFor(v => v.Post)
                .NotNull()
                .NotEmpty().WithMessage("don't miss the post")
                .MaximumLength(22);

        }
    }
}
