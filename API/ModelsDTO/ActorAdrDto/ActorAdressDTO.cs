using System.ComponentModel;

namespace API.ModelsDTO.ActorAdrDto
{
    public class ActorAdressDTO
    {
        [DisplayName("The first adress  for actor")]
        public string? Adress1 { get; set; }

        [DisplayName("The second adress  for actor")]
        public string? Adress2 { get; set; }

        [DisplayName("The City Name")]
        public string? City { get; set; }

        [DisplayName("The ZipCode Name")]
        public int ZipCode { get; set; }

        [DisplayName("The Country Name")]
        public string? Country { get; set; }

    }
}
