using API.ModelsDTO.ActorAdrDto;
using System.ComponentModel;

namespace API.ModelsDTO.ActorDto
{
    public class ActorAndAdressDTO
    {
        [DisplayName("First Name")]
        public string? FirstName { get; set; }

        [DisplayName("Last Name")]
        public string? LastName { get; set; }

        public virtual ActorAdressDTO? Adress { get; set; }
    }
}
