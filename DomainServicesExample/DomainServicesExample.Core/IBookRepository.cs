namespace DomainServicesExample.Core;

public interface IBookRepository
{
    Book Get(int id);
}