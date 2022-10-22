using API.ModelsDTO.ActorDto;
using API.ModelsDTO.GenreDto;
using System.ComponentModel;

namespace API.ModelsDTO.MovieDto
{
    public class MoviesWithDetailsDTO
    {
        [DisplayName("Realese Date")]
        public string? Title { get; set; }
        public DateTime RealeseDate { get; set; }

        [DisplayName("Genre Name")]
        public GenreDTO? GenreName { get; set; }

        public ICollection<ActorAndAdressDTO>? Actors { get; set; }
    }
}
