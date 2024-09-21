namespace WebAPI.Models;

public record ToDoResponse(int Id, string Name, List<ToDoItem> Items);

public record ToDoItem(int Id, string Task, string Status);
