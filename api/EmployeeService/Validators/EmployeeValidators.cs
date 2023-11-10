using EmployeeService.Dtos;
using EmployeeService.Repositories;
using FluentValidation;
using System.Threading;

namespace EmployeeService.Validators.EmployeeValidators
{
    public class GetEmployeeValidator : AbstractValidator<EmployeeGetDto>
    {
        public GetEmployeeValidator(IEmployeeQueriesRepository employeeRepository)
        {
            RuleFor(x => x.Id).Must((input) => employeeRepository.IsExistsById(input)).
                WithMessage("Элемента с таким Id не существует");
        }
    }

    public class AddEmployeeValidator : AbstractValidator<EmployeeAddDto>
    {
        public AddEmployeeValidator(IPositionQueriesRepository positionRepo, IDepartmentQueriesRepository departmentRepo)
        {
            RuleFor(x => x.Firstname).Length(2, 30).WithMessage("Имя должно иметь от {MinLength} до {MaxLength} символов");
            RuleFor(x => x.Lastname).Length(2, 30).WithMessage("Фамилия должна иметь от {MinLength} до {MaxLength} символов");
            When(x => x.Surname != null, () =>
            {
                RuleFor(x => x.Surname).Length(2, 30).
                WithMessage("Отчество должно иметь от {MinLength} до {MaxLength} символов");
            });

            RuleFor(x => x.DateOfEmployment).Must(date => date < DateTime.Now).WithMessage("Дата устройства не может быть больше текущей");
            RuleFor(x => x.DateOfBirth).Must(date => date < DateTime.Now).WithMessage("Дата рождения не может быть больше текущей");
            RuleFor(x => x.TariffRate).Must(x => x > 0).WithMessage("Оклад должен быть больше чем 0");
            RuleFor(x => x.DepartmentId).Must((id) => departmentRepo.IsExistsById(id)).WithMessage("Элемента с таким Id не существует");
            RuleFor(x => x.PostionId).Must((id) => positionRepo.IsExistsById(id)).WithMessage("Элемента с таким Id не существует");
        }
    }

    public class EditEmployeeValidator : AbstractValidator<EmployeeEditDto>
    {
        public EditEmployeeValidator(IPositionQueriesRepository positionRepo, IDepartmentQueriesRepository departmentRepo, IEmployeeQueriesRepository employeeRepo)
        {
            RuleFor(x => x.EmployeeId).Must((id) => employeeRepo.IsExistsById(id)).WithMessage("Элемента с таким Id не существует");
            RuleFor(x => x.Firstname).Length(2, 30).WithMessage("Имя должно иметь от {MinLength} до {MaxLength} символов");
            RuleFor(x => x.Lastname).Length(2, 30).WithMessage("Фамилия должна иметь от {MinLength} до {MaxLength} символов");
            When(x => x.Surname != null, () =>
            {
                RuleFor(x => x.Surname).Length(2, 30).
                WithMessage("Отчество должно иметь от {MinLength} до {MaxLength} символов");
            });

            RuleFor(x => x.DateOfEmployment).Must(date => date < DateTime.Now).WithMessage("Дата устройства не может быть больше текущей");
            RuleFor(x => x.DateOfBirth).Must(date => date < DateTime.Now).WithMessage("Дата рождения не может быть больше текущей");
            RuleFor(x => x.TariffRate).Must(x => x > 0).WithMessage("Оклад должен быть больше чем 0");
            RuleFor(x => x.DepartmentId).Must((id) => departmentRepo.IsExistsById(id)).WithMessage("Элемента с таким Id не существует");
            RuleFor(x => x.PostionId).Must((id) => positionRepo.IsExistsById(id)).WithMessage("Элемента с таким Id не существует");
        }
    }

    public class FilterEmployeeValidator : AbstractValidator<EmployeeFilterDto>
    {
        public FilterEmployeeValidator(IPositionQueriesRepository positionRepo)
        {
            RuleFor(x => x.Count).Must(x => x > 0 && x <= 30).WithMessage("Количество загружаемых элементов должно быть от 1 до 30");
            When(x => x.PositionId != 0, () =>
            {
                RuleFor(x => x.PositionId).Must(id => positionRepo.IsExistsById(id)).WithMessage("Элемента с таким Id не существует");
            });
            RuleFor(x => x.CountLoaded).Must(x => x >= 0).WithMessage("Количество звгруженных элементов должно быть >= 0");
        }
    }

}
