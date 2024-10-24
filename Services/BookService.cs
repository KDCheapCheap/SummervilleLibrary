using Microsoft.EntityFrameworkCore;
using SummervilleLibrary.Data;
using SummervilleLibrary.DTOs;
using SummervilleLibrary.Models.DatabaseEntities;
using SummervilleLibrary.Responses;
using System.Runtime.CompilerServices;

namespace SummervilleLibrary.Services;

public class BookService
{
    private readonly ApplicationDbContext _dbContext;

    private BookService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Book>> GetAllBooks()
    {
        return await _dbContext.Books.ToListAsync();
    }

    public async Task<RequestResponse<Book>> GetBookById(Guid id)
    {
        try
        {
            Book? getBook = await _dbContext.Books.FindAsync(id);

            if (getBook == null)
            {
                return new RequestResponse<Book>(false, $"Book with Id: {id} Not found.");
            }

            return new RequestResponse<Book>(true, "Book found successfully", getBook);
        }
        catch (Exception ex)
        {
            return new RequestResponse<Book>(false, $"GetBookById failed with Error. Message: {ex.Message}");
        }
    }

    public async Task<RequestResponse<Book>> AddBook(CreateBookDTO bookToAdd)
    {
        try
        {
            Book newBook = new Book()
            {
                Title = bookToAdd.Title,
                Author = bookToAdd.Author,
                Description = bookToAdd.Description,
                Genre = bookToAdd.Genre,
                PublicationYear = bookToAdd.PublicationYear,
                CreatedDate = DateTime.Now,
                CreatedBy = "System",
            };

            await _dbContext.Books.AddAsync(newBook);
            _dbContext.SaveChanges();

            return new RequestResponse<Book>(true, "Book Created Successfully", newBook);
        }
        catch (Exception ex)
        {
            return new RequestResponse<Book>(false, $"Book creation failed due to error. Message: {ex.Message}");
        }
    }

    public async Task<RequestResponse<Book>> UpdateBook(UpdateBookDTO edittedBook)
    {
        RequestResponse<Book> getBook = await GetBookById(edittedBook.Id);

        if (!getBook.Success || getBook.Data == null)
        {
            return new RequestResponse<Book>(false, "Cannot find book with ID in DTO.");
        }

        Book bookToEdit = getBook.Data;

        bookToEdit.Title = edittedBook.Title;
        bookToEdit.Author = edittedBook.Author;
        bookToEdit.Description = edittedBook.Description;
        bookToEdit.Genre = edittedBook.Genre;
        bookToEdit.PublicationYear = edittedBook.PublicationYear;
        bookToEdit.UpdatedDate = DateTime.Now;
        bookToEdit.UpdatedBy = "System";

        try
        {
            _dbContext.Books.Update(bookToEdit);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new RequestResponse<Book>(false, $"Book update failed with error. Message: {ex.Message}");
        }

        return new RequestResponse<Book>(true, $"Updated Book successfully", bookToEdit);
    }

    public async Task<BaseResponse> RemoveBook(Guid Id)
    {
        RequestResponse<Book> getBook = await GetBookById(Id);

        if (!getBook.Success || getBook.Data == null)
        {
            return new BaseResponse(false, "Cannot find book with ID in DTO.");
        }

        Book bookToDelete = getBook.Data;

        bookToDelete.SoftDelete();

        try
        {
            _dbContext.Update(bookToDelete);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new BaseResponse(false, $"Book deletion failed due to error. Message {ex.Message}");
        }

        return new BaseResponse(true, "Book deleted successfully");
    }
}
