using Core;

namespace Infrastructure;

public class ToDoItemRepository : IToDoItemRepository
{
    private readonly ToDoContext _context;

    public ToDoItemRepository(ToDoContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ToDoItem>> GetByListId(int listId)
    {
        return _context.ToDoItems.Where(w => w.ToDoListId == listId).ToList();
    }

    public async Task<ToDoItem> Get(int id)
    {
        return _context.ToDoItems.SingleOrDefault(s => s.Id == id);
    }
    
    public async Task<IEnumerable<ToDoItem>> Get(List<int> ids)
    {
        return _context.ToDoItems.Where(w => ids.Contains(w.Id));
    }
    
    public async Task Add(ToDoItem item)
    {
        await _context.Add(item);
    }
}