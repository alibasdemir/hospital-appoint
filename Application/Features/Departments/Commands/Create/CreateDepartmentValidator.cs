using FluentValidation;

namespace Application.Features.Departments.Commands.Create
{
    public class CreateDepartmentValidator : AbstractValidator<CreateDepartmentCommand>
    {
        public CreateDepartmentValidator()
        {
            RuleFor(i => i.Name).NotEmpty();
            RuleFor(i => i.Name).MinimumLength(1);

            RuleFor(i => i.Description).NotEmpty();
            RuleFor(i => i.Description).MinimumLength(2);
        }
    }
}
