using System.Collections.Generic;
using ToDoWebApplication.Services.DTOs.TaskBaseDTOs;

namespace ToDoWebApplication.Services.DTOs.UserDTOs
{
    public class UserForViewDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<TaskBaseForViewDTO> Tasks { get; set; }
    }
}
