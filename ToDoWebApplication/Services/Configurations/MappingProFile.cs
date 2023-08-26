using AutoMapper;
using System.Security.Cryptography.X509Certificates;
using ToDoWebApplication.Domian.Entities;
using ToDoWebApplication.Services.DTOs.AddDueDateDTOs;
using ToDoWebApplication.Services.DTOs.AddFileDTOs;
using ToDoWebApplication.Services.DTOs.CategoryDTOs;
using ToDoWebApplication.Services.DTOs.RepeatTimeDTOs;
using ToDoWebApplication.Services.DTOs.TaskBaseDTOs;
using ToDoWebApplication.Services.DTOs.UserDTOs;

namespace ToDoWebApplication.Services.Configurations
{
    public class MappingProFile : Profile
    {
        public MappingProFile()
        {
            CreateMap<AddDueDateForCreationDTO, AddDueDate>().ReverseMap();
            CreateMap<AddDueDateForViewDTOs, AddDueDate>().ReverseMap();

            CreateMap<AddFileForCreationDTOs, AddFile>().ReverseMap();
            CreateMap<AddFileForViewDTOs, AddFile>().ReverseMap();

            CreateMap<CategoryForCreationDTO, Category>().ReverseMap();
            CreateMap<CategoryForViewDTO, Category>().ReverseMap();

            CreateMap<RepeatTimeForCreationDTO, RepeatTime>().ReverseMap();
            CreateMap<RepeatTimeForViewDTO, RepeatTime>().ReverseMap();

            CreateMap<TaskBaseForViewDTO, TaskBase>().ReverseMap();
            CreateMap<TaskBaseForCreationDTO, TaskBase>().ReverseMap();

            CreateMap<UserForCreationDTO, User>().ReverseMap();
            CreateMap<UserForViewDTO, User>().ReverseMap();
            CreateMap<UserForPasswordChangeDTO, User>().ReverseMap();
        }

    }
}
