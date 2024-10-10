using Ardalis.ApiEndpoints;
using DomainServicesExample.Core;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DomainServicesExample.API.ReaderEndpoints;

public class CheckoutLibraryBookEndpoint : EndpointBaseAsync
    .WithRequest<CheckoutLibraryBookRequest>
    .WithoutResult
{
    private readonly IReaderRepository _readerRepository;
    private readonly IBookRepository _bookRepository;
    
    
    public CheckoutLibraryBookEndpoint(IReaderRepository readerRepository, IBookRepository bookRepository)
    {
        _readerRepository = readerRepository;
        _bookRepository = bookRepository;
    }
    
    [HttpPost("/readers/{readerId:int}/books/{bookId:int}")]
    [SwaggerOperation(
        Summary = "Checks out book to reader",
        Description = "Checks out book to reader",
        OperationId = "Reader_Checkout",
        Tags = new[] { "ReaderEndpoints" })
    ] 
    public override async Task<IActionResult> HandleAsync(CheckoutLibraryBookRequest request, CancellationToken token)
    {
        var reader = _readerRepository.Get(request.ReaderId);
        var book = _bookRepository.Get(request.BookId);

        if (book.CanLendBook())
        {
            reader.CheckoutBook(request.BookId);
            
            _readerRepository.Update(reader); 
            // Publish Domain Event (side effect) to update book
        }

        return Ok();
    }
}