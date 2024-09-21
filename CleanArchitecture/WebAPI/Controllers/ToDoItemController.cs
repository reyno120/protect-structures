using Application;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ToDoItemListController : ControllerBase
{
    private readonly IToDoItemService _toDoItemService;

    public ToDoItemListController(IToDoItemService toDoItemService)
    {
        _toDoItemService = toDoItemService;
    }
    
    
    [HttpPost]
    public async Task<IActionResult> Add(CreateToDoItemRequest request)
    {
        await _toDoItemService.CreateItem(request.ListId, request.Task);
        return NoContent();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateToDoItemRequest request)
    {
        await _toDoItemService.UpdateItem(id, request.Task, request.Status);
        return NoContent();
    }
    
    [HttpPut("")]
    public async Task<IActionResult> MassUpdate([FromQuery] int[] ids, MassUpdateToDoItemRequest request)
    {
        await _toDoItemService.MassUpdateItems(ids.ToList(), request.Status);
        return NoContent();
    }
}