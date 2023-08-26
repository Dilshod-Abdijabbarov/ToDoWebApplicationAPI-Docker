using ToDoWebApplication.Domian.Entities;

namespace ToDoWebApplication.Services.DTOs.RepeatTimeDTOs
{
    public class RepeatTimeForViewDTO
    {
        public int Id { get; set; }
        public int Nummer { get; set; }
        public RepeatEnum AddDateTime { get; set; }
        public int TaskBaseId { get; set; }
    }
}
