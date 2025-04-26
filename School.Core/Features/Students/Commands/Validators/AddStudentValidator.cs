using FluentValidation;
using School.Core.Features.Students.Commands.Models;

namespace School.Core.Features.Students.Commands.Validators
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        public AddStudentValidator()
        {

        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name must not be empty")
                .NotNull().WithMessage("Name must not be null")
                .MaximumLength(15).WithMessage("Max length is 15");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} must not be empty")
                .NotNull().WithMessage("{PropertyValue} must not be null")
                .MaximumLength(15).WithMessage("{PropertyName} length is 15");
        }

        public void ApplyCustomValidationRules()
        {

        }
    }
}
