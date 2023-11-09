using EmployeeService.Dtos;
using EmployeeService.Repositories;
using FluentValidation;

namespace EmployeeService.Validators.PositionValidators
{
    public class GetPositionValidator : AbstractValidator<PositionGetDto>
    {
        public GetPositionValidator(IPositionQueriesRepository positionRepo)
        {
            RuleFor(x => x.Id).Must((input) => positionRepo.IsExistsById(input)).WithMessage("Элемента с таким Id не существует");
        }
    }

    public class AddPositionValidator : AbstractValidator<PositionAddDto>
    {
        public AddPositionValidator(IPositionQueriesRepository positionRepo)
        {
            RuleFor(x => x.Name).Length(2, 100).WithMessage("Наименование должности должно иметь от {MinLength} до {MaxLength} символов");
            RuleFor(x => x.Name).Must(n => positionRepo.IsUniqueName(n)).WithMessage("Элемент с таким именем уже существует");
            RuleFor(x => x.SurplusFactor).Must(x => x > 1).WithMessage("Прибавочный коэффициент должен быть больше чем 1");
        }
    }

    public class EditPositionValidator : AbstractValidator<PositionEditDto>
    {
        public EditPositionValidator(IPositionQueriesRepository positionRepo)
        {
            RuleFor(x => x.Id).Must((id) => positionRepo.IsExistsById(id)).WithMessage("Элемента с таким Id не существует");
            RuleFor(x => x.Name).Length(2, 100).WithMessage("Наименование должности должно иметь от {MinLength} до {MaxLength} символов");
            RuleFor(x => x).Must(x => positionRepo.IsUniqueNameById(x.Name, x.Id)).WithMessage("Элемент с таким имененм уже существует");
            RuleFor(x => x.SurplusFactor).Must(x => x > 1).WithMessage("Прибавочный коэффициент должен быть больше чем 1");
        }
    }
}
