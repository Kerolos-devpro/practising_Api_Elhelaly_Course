using Demo.api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Demo.api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StudentsController(IStudentService studentService) : ControllerBase
{
    private readonly IStudentService _studentService = studentService;

    [HttpGet("")]
    public IActionResult GetAll()
    {
        return Ok(_studentService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get([FromRoute]int id)
    {
        var student = _studentService.Get(id);  

        return student is null ? NotFound() : Ok(student);
    }

    [HttpPost("")]
    public IActionResult Add([FromBody] Student student)
    {
        var newStudent = _studentService.Add(student);

        return CreatedAtAction(nameof(Get) , new { id = newStudent.Id} , newStudent);
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id , [FromBody] Student student)
    {
        var isUpdated = _studentService.Update(id , student);
        
        return !isUpdated ? NotFound() : NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var isDeleted = _studentService.Delete(id);

        return !isDeleted ? NotFound() : NoContent();
    }
}
