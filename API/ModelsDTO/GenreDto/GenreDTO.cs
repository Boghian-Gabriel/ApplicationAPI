using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.ModelsDTO.GenreDto
{
    public class GenreDTO : GenreNameDTO
    {
        public Guid IdGenre { get; set; }

        //public GenreDTO(Genre genre)
        //{
        //    GenreName = genre.GenreName;
        //}
    }
}
