using Ardalis.ApiEndpoints;
using DomainServicesExample.Core;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DomainServicesExample.API.ReaderEndpoints;

public class CheckoutLibraryBookUsingDomainServiceEndpoint : EndpointBaseAsync
    .WithRequest<CheckoutLibraryBookRequest>
    .WithoutResult
{
    private readonly IReaderRepository _readerRepository;
    private readonly IBookRepository _bookRepository;
    private readonly CheckoutService _checkoutService;
    
    
    public CheckoutLibraryBookUsingDomainServiceEndpoint(IReaderRepository readerRepository, 
        IBookRepository bookRepository,
        CheckoutService checkoutService)
    {
        _readerRepository = readerRepository;
        _bookRepository = bookRepository;
        _checkoutService = checkoutService;
    }
    
    [HttpPost("/v2/readers/{readerId:int}/books/{bookId:int}")]
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

        _checkoutService.Lend(reader, book);
        
        _readerRepository.Update(reader); 
        
        return Ok();
    }
}