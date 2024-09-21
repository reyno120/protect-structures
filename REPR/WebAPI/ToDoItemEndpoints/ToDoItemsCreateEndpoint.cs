using Application;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.ToDoItemEndpoints;

public record CreateToDoItemRequest(int ListId, string Task);

public class ToDoItemsCreateEndpoint : EndpointBaseAsync
    .WithRequest<CreateToDoItemRequest>
    .WithResult<IActionResult>
{
    private readonly IToDoItemService _toDoItemService;

    public ToDoItemsCreateEndpoint(IToDoItemService toDoItemService)
    {
        _toDoItemService = toDoItemService;
    }

    [HttpPost("/todoitems")]
    [SwaggerOperation(
        Summary = "Creates a ToDo Item",
        Description = "Creates a ToDo Item",
        OperationId = "ToDoItem_Create",
        Tags = new[] { "ToDoItemEndpoint" })
    ] 
    public override async Task<IActionResult> HandleAsync(CreateToDoItemRequest request, CancellationToken token)
    {
        await _toDoItemService.CreateItem(request.ListId, request.Task);
        return NoContent(); 
    }
}