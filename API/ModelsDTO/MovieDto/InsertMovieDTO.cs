﻿namespace API.ModelsDTO.MovieDto;

public class InsertMovieDTO
{
    public string? Title { get; set; }
    public DateTime RealeseDate { get; set; }

    public Guid IdRefGenre { get; set; }
}
