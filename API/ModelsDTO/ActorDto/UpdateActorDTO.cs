using System.ComponentModel.DataAnnotations;

namespace API.ModelsDTO.ActorDto
{
    public class UpdateActorDTO
    {
        [Required(ErrorMessage = "ActorId is required")]
        public Guid ActorId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(20, MinimumLength = 3)]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(20, MinimumLength = 3)]
        public string? LastName { get; set; }
    }
}
