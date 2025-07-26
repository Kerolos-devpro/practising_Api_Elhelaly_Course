namespace Demo.api.Contracts.Requests;

public class CreateStudentRequest
{
    public string Name { get; set; } = string.Empty;
    public double Grade { get; set; }
}
