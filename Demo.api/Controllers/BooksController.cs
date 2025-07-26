
namespace Demo.api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BooksController(IBookService bookService) : ControllerBase
{
    private readonly IBookService _bookService = bookService;

    [HttpGet("")]
    public IActionResult GetAll()
    {

        return Ok(_bookService.GetAll().MapToBookResponse());
    }

    [HttpGet("{id}")]
    public IActionResult Get([FromRoute]int id)
    {
        var book = _bookService.Get(id);

        return book is null ? NotFound() : Ok(book.MapToBookResponse());
    }

    [HttpPost("")]
    public IActionResult Add(CreateBookRequest request)
    {
        var newBook = _bookService.Add(request.MapToBook());
        return CreatedAtAction(nameof(Get) , new { id = newBook.Id} , newBook.MapToBookResponse());
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] CreateBookRequest request)
    {
        var isUpdated = _bookService.Update(id , request.MapToBook());
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
