using System.ComponentModel.DataAnnotations;

namespace ToDoWebApplication.Services.DTOs.UserDTOs
{
    public class UserForPasswordChangeDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}
