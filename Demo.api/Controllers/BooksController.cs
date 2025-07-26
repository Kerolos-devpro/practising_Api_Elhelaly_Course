using Demo.api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BooksController(IBookService bookService) : ControllerBase
{
    private readonly IBookService _bookService = bookService;

    [HttpGet("")]
    public IActionResult GetAll()
    {
        return Ok(_bookService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get([FromRoute]int id)
    {
        var book = _bookService.Get(id);

        return book is null ? NotFound() : Ok(book);
    }

    [HttpPost("")]
    public IActionResult Add(Book book)
    {
        var newBook = _bookService.Add(book);
        return CreatedAtAction(nameof(Get) , new { id = newBook.Id} , newBook);
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] Book book)
    {
        var isUpdated = _bookService.Update(id , book);
        if(!isUpdated)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    { 
       var isDeleted = _bookService.Delete(id);
         if(!isDeleted)
            return NotFound();

         return NoContent();
    }
}
