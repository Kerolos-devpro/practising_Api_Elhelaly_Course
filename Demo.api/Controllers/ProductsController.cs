using Demo.api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Demo.api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController(IProductService productService) : ControllerBase
{
    private readonly IProductService productService = productService;

    [HttpGet("")]
    public IActionResult GetAll()
    {
        return Ok(productService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var product = productService.Get(id);

        return product is null ? NotFound() : Ok(product);  
    }

    [HttpPost("")]
    public IActionResult Add(Product request)
    {
        var newProduct = productService.Add(request);

        return CreatedAtAction(nameof(Get) , new { id = request.Id} , newProduct);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int  id , Product request)
    {
        var isUpdated = productService.Update(id, request);

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
