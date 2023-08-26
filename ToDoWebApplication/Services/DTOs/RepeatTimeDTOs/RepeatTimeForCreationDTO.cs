using ToDoWebApplication.Domian.Entities;

namespace ToDoWebApplication.Services.DTOs.RepeatTimeDTOs
{
    public class RepeatTimeForCreationDTO
    {
        public int Nummer { get; set; }
        public RepeatEnum AddDateTime { get; set; }
        public int TaskBaseId { get; set; }
    }
}
