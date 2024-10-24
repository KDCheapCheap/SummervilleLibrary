using SummervilleLibrary.DTOs;
using SummervilleLibrary.Models.DatabaseEntities;
using SummervilleLibrary.Services.Interfaces;

namespace SummervilleLibrary.Components.Pages;

public partial class Home
{
    private readonly IBookService _bookService;
    
    public List<Book> allBooks;

    public Home(IBookService bookService)
    {
        _bookService = bookService;
    }


    protected override async Task OnInitializedAsync()
    {
        var exampleBook = new CreateBookDTO
        {
            Author = "George Orwell",
            Title = "1984",
            Description = "A dystopian novel set in a totalitarian society under constant surveillance.",
            Genre = "Dystopian, Science Fiction",
            PublicationYear = 1949
        };

        await _bookService.AddBook(exampleBook);

        allBooks = await _bookService.GetAllBooks();

        foreach (var book in allBooks)
        {
            Console.WriteLine(book.Title);
        }

    }
}
