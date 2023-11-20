using ApiDemo.Application.Book.Commands;
using FluentAssertions;

namespace ApiDemo.Application.UnitTest.Book;

public class InsertBookTest
{
    [Fact]
    public async Task Insert_ShouldReturnOk_IfObject()
    {
        // Arrange
        var handler = new InsertBookCommandHandler();

        // Act
        var command = new InsertBookCommand(new Models.Book
        {
            Id = Guid.Empty,
            Name = "Libro nuevo",
            PageCount = 99,
            PublishYear = DateTime.Now.Year
        });
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Name.Should().Be(command.Item.Name);
        result.PageCount.Should().Be(command.Item.PageCount);
        result.PublishYear.Should().Be(command.Item.PublishYear);
    }
}
