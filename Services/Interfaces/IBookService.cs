using SummervilleLibrary.DTOs;
using SummervilleLibrary.Models.DatabaseEntities;
using SummervilleLibrary.Responses;

namespace SummervilleLibrary.Services.Interfaces;

public interface IBookService
{
    Task<RequestResponse<Book>> AddBook(CreateBookDTO bookToAdd);
    Task<List<Book>> GetAllBooks();
    Task<RequestResponse<Book>> GetBookById(Guid id);
    Task<BaseResponse> RemoveBook(Guid Id);
    Task<RequestResponse<Book>> UpdateBook(UpdateBookDTO edittedBook);
}