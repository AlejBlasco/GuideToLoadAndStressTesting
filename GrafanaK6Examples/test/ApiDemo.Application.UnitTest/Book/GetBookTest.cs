using ApiDemo.Application.Book.Queries;
using FluentAssertions;

namespace ApiDemo.Application.UnitTest.Book;

public class GetBookTest
{
    public GetBookTest() { }

    [Fact]
    public async Task Get_ShouldReturnOk_IfRecordsOnDatabase()
    {
        // Arrange
        var handler = new GetBooksQueryHandler();

        // Act
        var result = await handler.Handle(new GetBooksQuery(), CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Should().NotBeEmpty();
    }
}
