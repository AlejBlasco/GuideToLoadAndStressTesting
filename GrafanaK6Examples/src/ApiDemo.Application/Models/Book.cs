namespace ApiDemo.Application.Models;

public class Book
{
    public Guid Id { get; set; } = Guid.Empty;

    public string Name { get; set; } = string.Empty;

    public int PageCount { get; set; }

    public int PublishYear { get; set; }
}