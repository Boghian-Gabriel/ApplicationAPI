using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.ModelsDTO.ActorDto
{
    public class ActorDTO
    {
        [DisplayName("First Name")]
        [StringLength(20, MinimumLength = 3)]
        [Required(ErrorMessage = "First Name is required")]
        public string? FirstName { get; set; }

        [DisplayName("Last Name")]
        [StringLength(20, MinimumLength = 3)]
        [Required(ErrorMessage = "Last Name is required")]
        public string? LastName { get; set; }
    }
}
