using ApiDemo.Application.Book.Queries;
using FluentAssertions;

namespace ApiDemo.Application.UnitTest.Book;

public class GetBookByIdTest
{
    [Fact]
    public async Task Get_ShouldReturnOk_IfRecordFound()
    {
        // Arrange
        var handler = new GetBooksByIdQueryHandler();

        // Act
        var query = new GetBooksByIdQuery() { Id = Guid.NewGuid() };
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(query.Id);
    }
}
