using AutoMapper;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperations.GetBooks;

public class GetBooksQuery
{
    private readonly BookStoreDbContext _dbContext; 
    
    private readonly IMapper _mapper; 
    
    public GetBooksQuery(BookStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public List<BooksViewModel> Handle()
    {
        var bookLists = _dbContext.Books.OrderBy(x => x.Id).ToList<Book>();

        List<BooksViewModel> viewModel = _mapper.Map<List<BooksViewModel>>(bookLists); 

        return viewModel;
    }
}

public class BooksViewModel
{
    public string Title { get; set; }

    public string Genre { get; set; }
    
    public int PageCount { get; set; }

    public string PublishDate { get; set; }   
}