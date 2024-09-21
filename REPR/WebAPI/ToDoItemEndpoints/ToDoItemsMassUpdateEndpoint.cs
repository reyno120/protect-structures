using Application;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.ToDoItemEndpoints;

public record MassUpdateToDoItemRequest([FromQuery] int[] Ids, [FromBody] string Status);

public class ToDoItemsMassUpdateEndpoint : EndpointBaseAsync
    .WithRequest<MassUpdateToDoItemRequest>
    .WithResult<IActionResult>
{
    private readonly IToDoItemService _toDoItemService;

    public ToDoItemsMassUpdateEndpoint(IToDoItemService toDoItemService)
    {
        _toDoItemService = toDoItemService;
    }

    [HttpPut("/todoitems")]
    [SwaggerOperation(
        Summary = "Mass Updates a ToDo Item",
        Description = "Mass Updates a ToDo Item",
        OperationId = "ToDoItem_MassUpdate",
        Tags = new[] { "ToDoItemEndpoint" })
    ]
    public override async Task<IActionResult> HandleAsync(MassUpdateToDoItemRequest request, CancellationToken token)
    {
        await _toDoItemService.MassUpdateItems(request.Ids.ToList(), request.Status);
        return NoContent(); 
    }
}