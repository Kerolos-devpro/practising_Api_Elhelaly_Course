
namespace Demo.api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController(IProductService productService) : ControllerBase
{
    private readonly IProductService productService = productService;

    [HttpGet("")]
    public IActionResult GetAll()
    {
        var products = productService.GetAll();
        return Ok(products.MapToProductResponse());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var product = productService.Get(id);

        return product is null ? NotFound() : Ok(product.MapToProductResponse());  
    }

    [HttpPost("")]
    public IActionResult Add(CreateProductRequest request)
    {
        var newProduct = productService.Add(request.MapToProduct());

        return CreatedAtAction(nameof(Get) , new { id = newProduct.Id} , newProduct.MapToProductResponse());
    }

    [HttpPut("{id}")]
    public IActionResult Update(int  id , CreateProductRequest request)
    {
        var isUpdated = productService.Update(id, request.MapToProduct());

        if (!isUpdated)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    { 
        var isDeleted = productService.Delete(id);
        if (!isDeleted)
            return NotFound();

        return NoContent();
    
    }
}
