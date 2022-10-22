using System.ComponentModel.DataAnnotations;

namespace API.ModelsDTO.GenreDto
{
    public class UpdateGenreDTO
    {
        [Required(ErrorMessage = "IdGenre is required")]
        public Guid IdGenre { get; set; }

        [Required(ErrorMessage = "GenreName is required")]
        [StringLength(20, MinimumLength = 2)]
        public string? GenreName { get; set; }
    }
}
