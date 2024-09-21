using AutoMapper;
using Core;
using WebAPI.Models;
using ToDoItem = Core.ToDoItem;

namespace WebAPI.MappingProfiles;

public class ToDoProfiles : Profile
{
    public ToDoProfiles()
    {
        CreateMap<ToDoList, ToDoResponse>();
        CreateMap<ToDoItem, Models.ToDoItem>();
    }
}