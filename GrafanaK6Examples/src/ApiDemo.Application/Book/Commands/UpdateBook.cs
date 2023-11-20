using FluentValidation;
using MediatR;

namespace ApiDemo.Application.Book.Commands;

public record UpdateBookCommand(Models.Book Item) : IRequest<Models.Book?>;

public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidator()
    {
        //TODO: Add validations
    }
}

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Models.Book?>
{
    public Task<Models.Book?> Handle(UpdateBookCommand command, CancellationToken cancellationToken)
    {

        if (command.Item != null)
        {
            System.Threading.Thread.Sleep(300); // Simulated operation.
            return Task.FromResult(command.Item);
        }
        else throw new ArgumentNullException(nameof(command));
    }
}

