using MediatR;

namespace ApiDemo.Application.Book.Queries;

public class Book
{
    public Guid Id { get; set; } = Guid.Empty;

    public string Name { get; set; } = string.Empty;

    public int PageCount { get; set; }

    public int PublishYear { get; set; }
}

public record GetBooksQuery : IRequest<IList<Book>>;

public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, IList<Book>>
{
    public Task<IList<Book>> Handle(GetBooksQuery query, CancellationToken cancellationToken)
    {
        IList<Book> bookList = new List<Book>();
        for (var i = 1; i <= 10; i++)
        {
            bookList.Add(new Book()
            {
                Id = Guid.NewGuid(),
                Name = $"Gran Enciclopedia de los DUMMIES vol. {i.ToString()}",
                PageCount = i * new Random().Next(100),
                PublishYear = 1900 + new Random().Next(100)
            });
        }

        return Task.FromResult(bookList);
    }
}
