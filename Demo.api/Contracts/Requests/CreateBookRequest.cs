namespace Demo.api.Contracts.Requests;

public class CreateBookRequest
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
