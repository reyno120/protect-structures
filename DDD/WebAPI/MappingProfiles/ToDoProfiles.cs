using AutoMapper;
using Core;
using WebAPI.ToDoListEndpoints;

namespace WebAPI.MappingProfiles;

public class ToDoProfiles : Profile
{
    public ToDoProfiles()
    {
        CreateMap<ToDoList, GetToDoListsResponse>();
        CreateMap<ToDoItem, GetToDoListsResponseToDoItem>();
    }
}