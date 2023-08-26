using ToDoWebApplication.Domian.Entities;

namespace ToDoWebApplication.Services.DTOs.AddDueDateDTOs
{
    public class AddDueDateForViewDTOs
    {
        public int Id { get; set; }
        public AddDueEnum FinishedTime { get; set; }
        public int TaskBaseId { get; set; }
    }
}
