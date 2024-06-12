using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.Create
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(i => i.Email).NotEmpty();
            RuleFor(i => i.Email).MinimumLength(1);

            RuleFor(i => i.Password).NotEmpty();
            RuleFor(i => i.Password).MinimumLength(6);

            RuleFor(i => i.FirstName).NotEmpty();
            RuleFor(i => i.FirstName).MinimumLength(1);

            RuleFor(i => i.LastName).NotEmpty();
            RuleFor(i => i.LastName).MinimumLength(1);

            RuleFor(i => i.Gender).NotEmpty();
        }
    }
}
