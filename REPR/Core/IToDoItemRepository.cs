namespace Core;

public interface IToDoItemRepository
{
    Task<IEnumerable<ToDoItem>> GetByListId(int listId);
    Task<ToDoItem> Get(int id);
    Task<IEnumerable<ToDoItem>> Get(List<int> ids);
    Task Add(ToDoItem item);
}