namespace Demo.api.Mapping;

public static class ContractMapping
{
    public static ProductResponse MapToProductResponse(this Product product)
    {
        return new () 
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
        };

    }
    public static IEnumerable<ProductResponse> MapToProductResponse(this IEnumerable<Product> products)
    {
        return products.Select(MapToProductResponse);

    }

    public static Product MapToProduct(this CreateProductRequest request)
    {
        return new()
        {
           Name = request.Name,
           Price = request.Price,
     
        };
    }

    public static BookResponse MapToBookResponse(this Book book)
    {
        return new()
        { 
            Id = book.Id,
            Description = book.Description,
            Title = book.Title,
        };

    }
    public static IEnumerable<BookResponse> MapToBookResponse(this IEnumerable<Book> books)
    {
        return books.Select(MapToBookResponse);

    }

    public static Book MapToBook(this CreateBookRequest request)
    {
        return new() 
        {
            Title = request.Title,
            Description = request.Description,
        };

    }

    public static StudentRespone MapToStudentResponse(this Student student)
    {
        return new()
        { 
          Id = student.Id,
          Grade = student.Grade,
          Name = student.Name,
        };
    }
    public static IEnumerable<StudentRespone> MapToStudentResponse(this IEnumerable<Student> students)
    {
        return students.Select(MapToStudentResponse);

    }

    public static Student MapToStudent(this CreateStudentRequest request)
    {
        return new() 
        {
          Name = request.Name,
          Grade = request.Grade,
        };
    }
}
