namespace DomainServicesExample.Core;

public class Book(string name, int numberOfCopies) : BaseEntity
{
    public string Name { get; private set; } = name;

    public int NumberOfCopies { get; private set; } = numberOfCopies;

    public int NumberOfCopiesCheckedOut { get; private set; }


    public void LendBook()
    {
        this.NumberOfCopiesCheckedOut++;
    }

    public bool CanLendBook()
    {
        return this.NumberOfCopiesCheckedOut < this.NumberOfCopies;
    }
}
