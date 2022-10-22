using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.ModelsDTO.GenreDto
{
    public class GenreDTO
    {
        [DisplayName(" The Genre name")]
        [Required(ErrorMessage = "Genre Name is required")]
        [StringLength(20, MinimumLength = 2)]
        public string? GenreName { get; set; }

        //public GenreDTO(Genre genre)
        //{
        //    GenreName = genre.GenreName;
        //}
    }
}
