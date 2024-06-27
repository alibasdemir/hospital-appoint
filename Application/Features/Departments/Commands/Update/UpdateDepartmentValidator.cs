using Application.Features.Departments.Commands.Update;
using FluentValidation;

namespace Application.Features.Departments.Commands.Create
{
    public class UpdateDepartmentValidator : AbstractValidator<UpdateDepartmentCommand>
    {
        public UpdateDepartmentValidator()
        {
			RuleFor(i => i.Name).NotEmpty().WithMessage("Name can not be empty.");
			RuleFor(i => i.Description).NotEmpty().WithMessage("LastName can not be empty.");
			//RuleFor(i => i.RequiredRoles).NotEmpty().WithMessage("Roles should be selected.");
		}
    }
}
