using API.Model;
using System.ComponentModel.DataAnnotations;

namespace API.ModelsDTO.UserDto
{
    public class UserRegistrationDTO
    {
        [Required(ErrorMessage = "UserName is required")]
        [StringLength(20, MinimumLength = 3)]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, MinimumLength = 3)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "RoleName is required")]
        [StringLength(20, MinimumLength = 4)]
        public string UserRole { get; set; }

    }
}
