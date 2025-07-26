
using System.Reflection.Metadata.Ecma335;

namespace Demo.api.Services;

public class BookService : IBookService
{
    private static readonly List<Book> _book = [
           new () 
           {
               Id = 1,
               Title = "Martin Luther",
               Description = "Desc"
           },
           new ()
           {
               Id = 2,
               Title = "First year of P.",
               Description = "Desc"
           },
           new ()
           {
               Id = 3,
               Title = "Hello World!",
               Description = "Desc"
           },
    ];


    public IEnumerable<Book> GetAll() => _book;
    
    public Book? Get(int id) => _book.SingleOrDefault(x=>x.Id == id);
    

    public Book Add(Book book)
    {
        book.Id = _book.Count + 1;
        _book.Add(book);
        return book;
    }

    public bool Update(int id, Book book)
    {
        var currentBook = Get(id);

        if (currentBook == null) 
            return false;

        currentBook.Title = book.Title;
        currentBook.Description = book.Description;

        return true;
    }

    public bool Delete(int id)
    {
       var book = Get(id);

        if(book == null)    
            return false;

        _book.Remove(book);
        return true;
    }
}
