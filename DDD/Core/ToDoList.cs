using Ardalis.GuardClauses;

namespace Core;

public class ToDoList
{
    public Guid Id { get; init; }
    public string Name { get; private set; }

    private readonly List<ToDoItem> _items = [];

    public IReadOnlyList<ToDoItem> Items => _items.AsReadOnly();

    public ToDoList(string name)
    {
        Guard.Against.NullOrEmpty(name);
        Guard.Against.LengthOutOfRange(name, 1, 50);

        this.Name = name;
        this.Id = Guid.NewGuid();
    }

    public void AddToDo(ToDoItem item)
    {
        if (_items.Any(a => a.Task.Equals(item.Task)))
            throw new InvalidOperationException("Task already exists with that name.");
        
        _items.Add(item);
    }
}