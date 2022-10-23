using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace API.ModelsDTO.UserDto
{
    public class UserLoginDTO
    {
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [StringLength(20, MinimumLength = 3)]
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
