using FluentValidation;

namespace Application.Features.Departments.Commands.Create
{
    public class CreateDepartmentValidator : AbstractValidator<CreateDepartmentCommand>
    {
        public CreateDepartmentValidator()
        {
			RuleFor(i => i.Name).NotEmpty().WithMessage("Name can not be empty.");
			RuleFor(i => i.Description).NotEmpty().WithMessage("Description can not be empty.");
			//RuleFor(i => i.RequiredRoles).NotEmpty().WithMessage("Roles should be selected.");
		}
    }
}
