using System.ComponentModel.DataAnnotations;

namespace API.ModelsDTO.MovieDto;

public class InsertMovieDTO
{
    [Required(ErrorMessage = "Password is required")]
    [StringLength(20, MinimumLength = 3)]
    public string? Title { get; set; }

    [Required(ErrorMessage = "RealeseDate is required")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime RealeseDate { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public Guid IdRefGenre { get; set; }
}
