using System.ComponentModel.DataAnnotations;

namespace API.ModelsDTO.MovieDto;

public class InsertMovieDTO
{
    [Required(ErrorMessage = "Title is required")]
    [StringLength(20, MinimumLength = 2)]
    public string? Title { get; set; }

    [Required(ErrorMessage = "Realese Date is required")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime RealeseDate { get; set; }

    [Required(ErrorMessage = "IdRefGenre is required")]
    public Guid IdRefGenre { get; set; }
}
