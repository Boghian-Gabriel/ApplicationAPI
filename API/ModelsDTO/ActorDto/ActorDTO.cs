using System.ComponentModel;

namespace API.ModelsDTO.ActorDto
{
    public class ActorDTO
    {
        [DisplayName("First Name")]
        public string? FirstName { get; set; }

        [DisplayName("Last Name")]
        public string? LastName { get; set; }
    }
}
