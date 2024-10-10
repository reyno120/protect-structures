namespace DomainServicesExample.Core;

public interface IReaderRepository
{
    Reader Get(int id);
    void Update(Reader reader);
}