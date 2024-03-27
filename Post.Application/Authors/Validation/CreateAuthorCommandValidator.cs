using FluentValidation;
using Post.Application.Authors.Commands.CreateAuthor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Application.Authors.Validation
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(v => v.AuthorName)
                .NotEmpty().WithMessage("Author Name is required .")
                .MaximumLength(70).WithMessage("must not 70 characters");

            RuleFor(v => v.Description)
                .NotEmpty().WithMessage("Description is required");

            RuleFor(v => v.Post)
                .NotEmpty().WithMessage("Post is required")
                .MaximumLength(22).WithMessage("mist not 22 characters");
        }
    }
}
