using System.ComponentModel.DataAnnotations;

namespace API.ModelsDTO.ActorAdrDto
{
    public class InsertActorAdressWithActorID
    {
        [Required(ErrorMessage = "ActorAdressId is required")]
        public Guid ActorAdressId { get; set; }

        [Required(ErrorMessage = "Adress1 is required")]
        [StringLength(20, MinimumLength = 3)]
        public string? Adress1 { get; set; }

        [Required(ErrorMessage = "Adress2 is required")]
        [StringLength(20, MinimumLength = 3)]
        public string? Adress2 { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(20, MinimumLength = 3)]
        public string? City { get; set; }

        [Required(ErrorMessage = "ZipCode is required")]
        [StringLength(20, MinimumLength = 3)]
        public int ZipCode { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [StringLength(20, MinimumLength = 3)]
        public string? Country { get; set; }
    }
}
