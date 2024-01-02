using WebApi.DbOperations;

namespace WebApi.BookOperations.UpdateBook;

public class UpdateBookCommand
{
    private readonly BookStoreDbContext _dbContext;
    public int BookId { get; set; }

    public UpdateBookModel Model { get; set; }
    
    public UpdateBookCommand(BookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Handle()
    {
        var book = _dbContext.Books.SingleOrDefault(x => x.Id==BookId);

        if (book is not null)  throw new InvalidOperationException("Book to be updated not found!");

        book.Title = Model.Title != default ? Model.Title : book.Title;
        book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
        
        _dbContext.SaveChanges(); 
    }

}

public class UpdateBookModel
{
    public string Title { get; set; }

    public int GenreId { get; set; }  
}