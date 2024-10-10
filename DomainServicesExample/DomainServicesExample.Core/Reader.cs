namespace DomainServicesExample.Core;

public class Reader : BaseEntity
{
    private List<int> _checkedOutBookIds = [];
    public IReadOnlyList<int> CheckedOutBookIds => _checkedOutBookIds.AsReadOnly();

    public void CheckoutBook(int id)
    {
        if (!CanCheckout())
            throw new Exception("Maximum # of books allowed.");

        if (_checkedOutBookIds.Contains(id))
            throw new Exception("Book already checked out to Reader.");
        
        _checkedOutBookIds.Add(id);
    }

    public bool CanCheckout()
    {
        return _checkedOutBookIds.Count <= 10;
    }
}