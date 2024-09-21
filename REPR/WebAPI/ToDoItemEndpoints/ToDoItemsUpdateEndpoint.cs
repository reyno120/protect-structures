using Application;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.ToDoItemEndpoints;

public record UpdateToDoItemRequest([FromRoute] int Id, [FromBody] string Task, [FromBody] string Status);

public class ToDoItemsUpdateEndpoint : EndpointBaseAsync
    .WithRequest<UpdateToDoItemRequest>
    .WithResult<IActionResult>
{
    private readonly IToDoItemService _toDoItemService;

    public ToDoItemsUpdateEndpoint(IToDoItemService toDoItemService)
    {
        _toDoItemService = toDoItemService;
    }

    [HttpPut("/todoitems/{id:int}")]
    [SwaggerOperation(
        Summary = "Updates a ToDo Item",
        Description = "Updates a ToDo Item",
        OperationId = "ToDoItem_Update",
        Tags = new[] { "ToDoItemEndpoint" })
    ] 
    public override async Task<IActionResult> HandleAsync(UpdateToDoItemRequest request, CancellationToken token)
    {
        await _toDoItemService.UpdateItem(request.Id, request.Task, request.Status);
        return NoContent();
    } 
}