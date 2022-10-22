using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.ModelsDTO.MovieDto
{
    public class MovieDTO
    {
        [DisplayName("The Movie title")]
        public string? Title { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Realese Date")]
        public DateTime RealeseDate { get; set; }
    }
}
