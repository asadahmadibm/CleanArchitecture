using Application.MediatR.Members.Commands.Create;

namespace Application.TodoItems.Commands.CreateTodoItem;

public class CreateMemberCommandValidator : AbstractValidator<CreateMemberCommand>
{
    public CreateMemberCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(30)
            .NotEmpty();
    }
}
