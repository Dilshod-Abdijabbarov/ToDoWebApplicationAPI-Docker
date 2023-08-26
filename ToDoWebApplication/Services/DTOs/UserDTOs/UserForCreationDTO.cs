using System.ComponentModel.DataAnnotations;

namespace ToDoWebApplication.Services.DTOs.UserDTOs
{
    public class UserForCreationDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
