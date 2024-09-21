using Ardalis.ApiEndpoints;
using AutoMapper;
using Core;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.ToDoListEndpoints;

public record GetToDoListsResponse(int Id, string Name, List<GetToDoListsResponseToDoItem> Items);
public record GetToDoListsResponseToDoItem(int Id, string Task, string Status);

public class ToDoListsGetEndpoint : EndpointBaseAsync
    .WithoutRequest
    .WithResult<IActionResult>
{
    private readonly IMapper _mapper;
    private readonly IToDoListRepository _toDoListRepository;

    public ToDoListsGetEndpoint(IMapper mapper, 
        IToDoListRepository toDoListRepository)
    {
        _mapper = mapper;
        _toDoListRepository = toDoListRepository;
    }

    [HttpGet("/todolists")]
    [SwaggerOperation(
        Summary = "Gets all To Do Lists",
        Description = "Gets all To Do Lists",
        OperationId = "ToDoList_Get",
        Tags = new[] { "ToDoListEndpoint" })
    ]
    public override async Task<IActionResult> HandleAsync(CancellationToken token)
    {
        var toDoLists = await _toDoListRepository.Get();
        if (toDoLists is null)
            return BadRequest();

        return Ok(_mapper.Map<IEnumerable<GetToDoListsResponse>>(toDoLists));
    }
}