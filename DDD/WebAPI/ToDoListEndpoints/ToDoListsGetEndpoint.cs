using Ardalis.ApiEndpoints;
using AutoMapper;
using Core;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.ToDoListEndpoints;

public record GetToDoListsResponse(Guid Id, string Name, List<GetToDoListsResponseToDoItem> Items);
public record GetToDoListsResponseToDoItem(Guid Id, string Task, string Status);

public class ToDoListsGetEndpoint : EndpointBaseAsync
    .WithoutRequest
    .WithResult<IActionResult>
{
    private readonly IMapper _mapper;
    // private readonly IBoardRepository _boardRepository;
    private readonly ToDoContext _context;

    public ToDoListsGetEndpoint(IMapper mapper, 
        // IBoardRepository boardRepository,
        ToDoContext context
        )
    {
        _mapper = mapper;
        // _boardRepository = boardRepository;
        _context = context;
    }

    [HttpGet(Resources.ToDoListRoute)]
    [SwaggerOperation(
        Summary = "Gets all To Do Lists",
        Description = "Gets all To Do Lists",
        OperationId = "ToDoList_Get",
        Tags = new[] { "ToDoListEndpoint" })
    ]
    public override async Task<IActionResult> HandleAsync(CancellationToken token)
    {
        // var board = await _boardRepository.Get();
        var board = _context.Board;
        if (board is null)
            return BadRequest();

        return Ok(_mapper.Map<IEnumerable<GetToDoListsResponse>>(board.ToDoLists));
    }
}