using Ardalis.GuardClauses;
using Core;

namespace Application;

public class ToDoListService : IToDoListService
{
    private readonly IToDoListRepository _toDoListRepository;

    public ToDoListService(IToDoListRepository toDoListRepository)
    {
        _toDoListRepository = toDoListRepository;
    }

    public async Task CreateList(string name)
    {
        var toDoLists = await _toDoListRepository.Get();
        if (toDoLists.Any(a => a.Name.Equals(name)))
            throw new InvalidOperationException("List already exists with that Name.");

        Guard.Against.NullOrEmpty(name);
        Guard.Against.LengthOutOfRange(name, 1, 50);
        
        var toDoList = new ToDoList()
        {
            Name = name
        };
        
       await _toDoListRepository.Add(toDoList);
    }
}