using Application;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.ToDoListEndpoints;

public record CreateToDoListRequest(string Name);

public class ToDoListsCreateEndpoint : EndpointBaseAsync
    .WithRequest<CreateToDoListRequest>
    .WithResult<IActionResult>
{
    private readonly IToDoListService _toDoListService;
    
    public ToDoListsCreateEndpoint(IToDoListService toDoListService)
    {
        _toDoListService = toDoListService;
    }

    [HttpPost("/todolists")]
    [SwaggerOperation(
        Summary = "Creates a new To Do List",
        Description = "Creates a new To Do List",
        OperationId = "ToDoList_Create",
        Tags = new[] { "ToDoListEndpoint" })
    ]
    public override async Task<IActionResult> HandleAsync(CreateToDoListRequest request, CancellationToken token) 
    {
        await _toDoListService.CreateList(request.Name);
        return NoContent();
    }
}