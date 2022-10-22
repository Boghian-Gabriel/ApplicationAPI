using System.ComponentModel;

namespace API.ModelsDTO.GenreDto
{
    public class GenreDTO
    {
        [DisplayName(" The Genre name")]
        public string? GenreName { get; set; }

        //public GenreDTO(Genre genre)
        //{
        //    GenreName = genre.GenreName;
        //}
    }
}
