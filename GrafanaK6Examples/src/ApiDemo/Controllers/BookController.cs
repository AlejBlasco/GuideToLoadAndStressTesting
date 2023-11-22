using ApiDemo.Application.Book.Commands;
using ApiDemo.Application.Book.Queries;
using ApiDemo.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly ISender mediator;

    public BookController(ISender mediator)
    {
        this.mediator = mediator
            ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await mediator.Send(new GetBooksQuery());

        if (result != null)
            return Ok(result);
        else
            return NotFound();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await mediator.Send(new GetBooksByIdQuery { Id = id });

        if (result != null)
            return Ok(result);
        else
            return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Insert(Book request)
    {
        var result = await mediator.Send(new InsertBookCommand(request));
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(Book request)
    {
        var result = await mediator.Send(new UpdateBookCommand(request));
        return Ok(result);
    }
}
