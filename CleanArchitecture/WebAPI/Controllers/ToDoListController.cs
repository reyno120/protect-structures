using Application;
using AutoMapper;
using Core;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ToDoListController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IToDoListService _toDoListService;
    private readonly IToDoListRepository _toDoListRepository; 

    public ToDoListController(IMapper mapper, IToDoListService toDoListService, IToDoListRepository toDoListRepository)
    {
        _mapper = mapper;
        _toDoListService = toDoListService;
        _toDoListRepository = toDoListRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var toDoLists = await _toDoListRepository.Get();
        if (toDoLists is null)
            return BadRequest();

        return Ok(_mapper.Map<IEnumerable<ToDoResponse>>(toDoLists));
    }
    
    [HttpPost]
    public async Task<IActionResult> Add(CreateToDoListRequest request)
    {
        await _toDoListService.CreateList(request.Name);
        return NoContent();
    }
}