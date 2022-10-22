using System.ComponentModel.DataAnnotations;

namespace API.ModelsDTO.UserDto
{
    public class UpdateUserDTO
    {
        [Required(ErrorMessage = "UserId is required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "UserName is required")]
        [StringLength(20, MinimumLength = 3)]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, MinimumLength = 5)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Status is required (true or false)")]
        public bool? isActive { get; set; } 
    }
}
