using Core;

namespace Infrastructure;

public class ToDoContext
{
    // ToDoList
    private List<ToDoList> _toDoLists =
    [
        new ToDoList() 
        { 
            Id = 1, 
            Name = "List 1", 
            Items =
            [
                new ToDoItem() { Id = 1, Task = "Task 1", Status = "To Do", ToDoListId = 1 },
                new ToDoItem() { Id = 2, Task = "Task 2", Status = "To Do", ToDoListId = 1 }
            ]
        },
        new ToDoList()
        {
            Id = 2, 
            Name = "List 2",
            Items = [new ToDoItem() { Id = 3, Task = "Task 1", Status = "To Do", ToDoListId = 2}]
        }
    ];

    public IReadOnlyList<ToDoList> ToDoLists => _toDoLists.AsReadOnly();
    public IReadOnlyList<ToDoItem> ToDoItems => _toDoLists.SelectMany(s => s.Items).ToList().AsReadOnly();

    public async Task Add(ToDoList newList)
    {
        var highestId = _toDoLists.MaxBy(o => o.Id)?.Id ?? 0;
        newList.Id = highestId + 1;
        _toDoLists.Add(newList);
    }
    
    
    // ToDoItems
    public async Task Add(ToDoItem item)
    {
        var highestId = _toDoLists.SelectMany(s => s.Items).MaxBy(m => m.Id)?.Id ?? 0;
        
        var list = _toDoLists.SingleOrDefault(s => s.Id == item.ToDoListId);
        if (list is null) return;

        item.Id = highestId + 1;
        list.Items.Add(item);
    }
}



