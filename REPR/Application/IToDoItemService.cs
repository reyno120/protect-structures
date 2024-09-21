namespace Application;

public interface IToDoItemService
{
    Task CreateItem(int listId, string task);
    Task UpdateItem(int id, string task, string status);
    Task MassUpdateItems(List<int> ids, string status);
}