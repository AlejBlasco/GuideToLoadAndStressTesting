using MediatR;

namespace ApiDemo.Application.Book.Queries;

public record GetBooksByIdQuery : IRequest<Models.Book>
{
    public Guid Id { get; set; } = Guid.Empty;
}

public class GetBooksByIdQueryHandler : IRequestHandler<GetBooksByIdQuery, Models.Book>
{
    public Task<Models.Book> Handle(GetBooksByIdQuery query, CancellationToken cancellationToken)
    {
        var match = new Models.Book()
        {
            Id = query.Id,
            Name = $"El libro que buscabas",
            PageCount = new Random().Next(100),
            PublishYear = 1900 + new Random().Next(100)
        };

        return Task.FromResult(match);
    }
}
