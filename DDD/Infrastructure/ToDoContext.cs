using Core;

namespace Infrastructure;

public class ToDoContext
{
    public Board Board { get; private set; } = new Board(); 
    
    public ToDoContext()
    {
        var list1 = new ToDoList("List 1");
        list1.AddToDo(new ToDoItem("Task 1"));
        list1.AddToDo(new ToDoItem("Task 2"));

        var list2 = new ToDoList("List 2");
        list2.AddToDo(new ToDoItem("Task 1"));
        
        Board.AddNewToDoList(list1);
        Board.AddNewToDoList(list2);
    }
}



