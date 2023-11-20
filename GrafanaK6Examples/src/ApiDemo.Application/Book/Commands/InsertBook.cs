using FluentValidation;
using MediatR;

namespace ApiDemo.Application.Book.Commands;

public record InsertBookCommand(Models.Book Item) : IRequest<Models.Book?>;

public class InsertBookCommandValidator : AbstractValidator<InsertBookCommand>
{
    public InsertBookCommandValidator()
    {
        //TODO: Add validations
    }
}

public class InsertBookCommandHandler : IRequestHandler<InsertBookCommand, Models.Book?>
{
    public Task<Models.Book?> Handle(InsertBookCommand command, CancellationToken cancellationToken)
    {

        if (command.Item != null)
        {
            command.Item.Id = Guid.NewGuid();
            System.Threading.Thread.Sleep(300); // Simulated operation.
            return Task.FromResult(command.Item);
        }
        else throw new ArgumentNullException(nameof(command));
    }
}

