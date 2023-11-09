using EmployeeService.Dtos;
using EmployeeService.Repositories;
using FluentValidation;

namespace EmployeeService.Validators.DepartmentValidators
{
    public class GetDepartmentValidator : AbstractValidator<DepartmentGetDto>
    {
        public GetDepartmentValidator(IDepartmentQueriesRepository departmentRepo)
        {
            RuleFor(x => x.Id).Must((input) => departmentRepo.IsExistsById(input)).WithMessage("Элемента с таким Id не существует");
        }
    }

    public class AddDepartmentValidator : AbstractValidator<DepartmentAddDto>
    {
        public AddDepartmentValidator(IDepartmentQueriesRepository departmentRepo)
        {
            RuleFor(x => x.Name).Length(1, 100).WithMessage("Наименование отдела должно иметь от {MinLength} до {MaxLength} символов");
            RuleFor(x => x.Name).Must(n => departmentRepo.IsUniqueName(n)).WithMessage("Элемент с таким именем уже существует");
        }
    }

    public class EditDepartmentValidator : AbstractValidator<DepartmentEditDto>
    {
        public EditDepartmentValidator(IDepartmentQueriesRepository departmentRepo)
        {
            RuleFor(x => x.Id).Must((id) => departmentRepo.IsExistsById(id)).WithMessage("Элемента с таким Id не существует");
            RuleFor(x => x.Name).Length(1, 100).WithMessage("Наименование отдела должно иметь от {MinLength} до {MaxLength} символов");
            RuleFor(x => x).Must(x => departmentRepo.IsUniqueNameById(x.Name, x.Id)).WithMessage("Элемент с таким именем уже существует");
        }
    }
}
