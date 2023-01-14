using FluentValidation;

namespace BuberDinner.Application.Menus.CreateMenu.Commands;

public class CreateMenuValidator : AbstractValidator<CreateMenuCommand>
{
    public CreateMenuValidator()
    {
        RuleFor(x=>x.Name).NotEmpty();  
    }
}
