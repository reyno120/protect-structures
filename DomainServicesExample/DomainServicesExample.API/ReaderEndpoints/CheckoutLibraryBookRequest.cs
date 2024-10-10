using Microsoft.AspNetCore.Mvc;

namespace DomainServicesExample.API.ReaderEndpoints;

public record CheckoutLibraryBookRequest([FromRoute] int ReaderId, [FromRoute] int BookId);