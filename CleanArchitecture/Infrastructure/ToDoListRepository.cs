using Core;

namespace Infrastructure;

public class ToDoListRepository(ToDoContext context) : IToDoListRepository
{
    public async Task<IEnumerable<ToDoList>> Get()
    {
        return context.ToDoLists.ToList();
    }

    public async Task Add(ToDoList list)
    {
        await context.Add(list);
    }
}