using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.ModelsDTO.MovieDto
{
    public class MovieDTO
    {
        [DisplayName("Movie Title")]
        public string? Title { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Realese Date")]
        public DateTime RealeseDate { get; set; }
    }
}
