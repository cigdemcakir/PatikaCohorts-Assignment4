using AutoMapper;
using WebApi.BookOperations.GetBooks;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperations.GetBookDetail;

public class GetBookDetailQuery
{
    private readonly BookStoreDbContext _dbContext;
    
    private readonly IMapper _mapper; 
    
    public int BookId { get; set; } 

    public GetBookDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public BookDetailViewModel Handle()
    {
        var book = _dbContext.Books.Where(x => x.Id==BookId).SingleOrDefault();

        if (book is null) throw new InvalidOperationException($"Book with ID {BookId} not found.");

        BookDetailViewModel viewModel = _mapper.Map<BookDetailViewModel>(book);

        return viewModel;
    }
}

public class BookDetailViewModel
{

    public string Title { get; set; }

    public string Genre { get; set; }
    
    public int PageCount { get; set; }

    public string PublishDate { get; set; }   
}