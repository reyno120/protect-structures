using Ardalis.ApiEndpoints;
using Core;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.ToDoListEndpoints;

public record CreateToDoListRequest(string Name);

public class ToDoListsCreateEndpoint : EndpointBaseAsync
    .WithRequest<CreateToDoListRequest>
    .WithResult<IActionResult>
{
    private readonly IBoardRepository _boardRepository;
    
    public ToDoListsCreateEndpoint(IBoardRepository boardRepository)
    {
        _boardRepository = boardRepository;
    }

    [HttpPost(Resources.ToDoListRoute)]
    [SwaggerOperation(
        Summary = "Creates a new To Do List",
        Description = "Creates a new To Do List",
        OperationId = "ToDoList_Create",
        Tags = new[] { "ToDoListEndpoint" })
    ]
    public override async Task<IActionResult> HandleAsync(CreateToDoListRequest request, CancellationToken token)
    {
        var board = await _boardRepository.Get();
        
        var newList = new ToDoList(request.Name);
        board.AddNewToDoList(newList);
        
        return NoContent();
    }
}