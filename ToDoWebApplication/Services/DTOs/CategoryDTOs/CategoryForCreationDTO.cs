using ToDoWebApplication.Domian.Entities;
using ToDoWebApplication.Services.DTOs.TaskBaseDTOs;

namespace ToDoWebApplication.Services.DTOs.CategoryDTOs
{
    public class CategoryForCreationDTO
    {
        public CategoryEnum AddDateTime { get; set; }
        public int TaskBaseId { get; set; }
    }
}
