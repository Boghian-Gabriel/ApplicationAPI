using System.ComponentModel;

namespace API.ModelsDTO.UserDto
{
    public class UserDTO
    {
        [DisplayName("User name")]
        public string? UserName { get; set; }

        [DisplayName("E-mail")]
        public string? Email { get; set; }

        [DisplayName("Password")]
        public string? Password { get; set; }

        [DisplayName("Status if user is active or not")]
        public bool? isActive { get; set; }
    }
}
