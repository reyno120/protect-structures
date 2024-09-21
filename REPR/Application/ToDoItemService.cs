using Ardalis.GuardClauses;
using Core;

namespace Application;

public class ToDoItemService : IToDoItemService
{
    private readonly IToDoItemRepository _toDoItemRepository;

    public ToDoItemService(IToDoItemRepository toDoItemRepository)
    {
        _toDoItemRepository = toDoItemRepository;
    }

    public async Task CreateItem(int listId, string task)
    {
        var toDoItems = await _toDoItemRepository.GetByListId(listId);
        if (toDoItems.Any(a => a.Task.Equals(task)))
            throw new InvalidOperationException("Task already exists with that name.");

        Guard.Against.NullOrEmpty(task);
        Guard.Against.LengthOutOfRange(task, 1, 50);

        var newToDoItem = new ToDoItem()
        {
            Task = task,
            ToDoListId = listId,
            Status = "To Do"
        };

        await _toDoItemRepository.Add(newToDoItem);
    }

    public async Task UpdateItem(int id, string task, string status)
    {
        var item = await _toDoItemRepository.Get(id);
        
        var itemsInList = await _toDoItemRepository.GetByListId(item.ToDoListId)
            .ContinueWith(c => c.Result.ToList());
        itemsInList.Remove(item);
        if (itemsInList.Any(a => a.Task.Equals(task)))
            throw new InvalidOperationException("Task already exists with that name."); 
        
        Guard.Against.NullOrEmpty(task);
        Guard.Against.LengthOutOfRange(task, 1, 50);

        var isStatusValid = status.Equals("To Do") || status.Equals("In Progress") || status.Equals("Done");
        if (!isStatusValid)
            throw new InvalidOperationException("Status is invalid.");

        item.Status = status;
        item.Task = task;
    }
    
    public async Task MassUpdateItems(List<int> ids, string status)
    {
        var isStatusValid = status.Equals("To Do") || status.Equals("In Progress") || status.Equals("Done");
        if (!isStatusValid)
            throw new InvalidOperationException("Status is invalid.");
        
        var items = await _toDoItemRepository.Get(ids);
        foreach (var item in items)
        {
            item.Status = status;
        }
    }
}