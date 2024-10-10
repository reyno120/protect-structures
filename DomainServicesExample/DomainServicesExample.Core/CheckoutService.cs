namespace DomainServicesExample.Core;

public class CheckoutService
{
    public void Lend(Reader reader, Book book)
    {
        if (book.CanLendBook())
        {
            reader.CheckoutBook(book.Id);
            // public domain event inside CheckoutBook
        } 
    }
}