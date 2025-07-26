

namespace Demo.api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StudentsController(IStudentService studentService) : ControllerBase
{
    private readonly IStudentService _studentService = studentService;

    [HttpGet("")]
    public IActionResult GetAll()
    {
        var students = _studentService.GetAll();
        return Ok(students.MapToStudentResponse());
    }

    [HttpGet("{id}")]
    public IActionResult Get([FromRoute]int id)
    {
        var student = _studentService.Get(id);  

        return student is null ? NotFound() : Ok(student.MapToStudentResponse());
    }

    [HttpPost("")]
    public IActionResult Add([FromBody] CreateStudentRequest request)
    {
        var newStudent = _studentService.Add(request.MapToStudent());

        return CreatedAtAction(nameof(Get) , new { id = newStudent.Id} , newStudent.MapToStudentResponse());
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id , [FromBody] CreateStudentRequest request)
    {
        var isUpdated = _studentService.Update(id , request.MapToStudent());
        
        return !isUpdated ? NotFound() : NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var isDeleted = _studentService.Delete(id);

        return !isDeleted ? NotFound() : NoContent();
    }
}
