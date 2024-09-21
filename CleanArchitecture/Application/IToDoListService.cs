namespace Application;

public interface IToDoListService
{
    Task CreateList(string name);
}