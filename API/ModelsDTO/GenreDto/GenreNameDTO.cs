using System.ComponentModel.DataAnnotations;

namespace API.ModelsDTO.GenreDto
{
    public class GenreNameDTO
    {
        [Required(ErrorMessage = "Genre Name is required")]
        [StringLength(20, MinimumLength = 2)]
        public string? GenreName { get; set; }
    }
}
