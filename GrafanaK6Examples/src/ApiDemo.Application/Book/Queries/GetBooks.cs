using MediatR;

namespace ApiDemo.Application.Book.Queries;

public record GetBooksQuery : IRequest<IList<Models.Book>>;

public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, IList<Models.Book>>
{
    public Task<IList<Models.Book>> Handle(GetBooksQuery query, CancellationToken cancellationToken)
    {
        IList<Models.Book> bookList = new List<Models.Book>();
        for (var i = 1; i <= 10; i++)
        {
            bookList.Add(new Models.Book()
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
