using ToDoWebApplication.Domian.Entities;

namespace ToDoWebApplication.Services.DTOs.CategoryDTOs
{
    public class CategoryForViewDTO
    {
        public int Id { get; set; }
        public CategoryEnum AddDateTime { get; set; }
        public int TaskBaseId { get; set; }
    }
}
