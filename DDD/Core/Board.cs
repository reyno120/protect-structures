namespace Core;

public class Board : IAggregateRoot
{
    private readonly List<ToDoList> _toDoLists = [];
    public IReadOnlyList<ToDoList> ToDoLists => _toDoLists.AsReadOnly();

    public void AddNewToDoList(ToDoList toDoList)
    {
        if (_toDoLists.Any(a => a.Name.Equals(toDoList.Name)))
            throw new InvalidOperationException("List already exists with that Name.");
        
        _toDoLists.Add(toDoList);
    }
}