namespace Core;

public interface IToDoListRepository
{
    Task<IEnumerable<ToDoList>> Get();
    Task Add(ToDoList list);
}