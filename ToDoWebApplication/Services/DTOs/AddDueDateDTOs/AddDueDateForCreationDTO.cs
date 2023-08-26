using ToDoWebApplication.Domian.Entities;

namespace ToDoWebApplication.Services.DTOs.AddDueDateDTOs
{
    public class AddDueDateForCreationDTO
    {
        public AddDueEnum FinishedTime { get; set; }
        public int TaskBaseId { get; set; }
    }
}
