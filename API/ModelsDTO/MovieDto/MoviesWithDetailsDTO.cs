using API.ModelsDTO.ActorDto;
using API.ModelsDTO.GenreDto;
using System.ComponentModel;

namespace API.ModelsDTO.MovieDto
{
    public class MoviesWithDetailsDTO
    {
        [DisplayName("The Movie title")]
        public string? Title { get; set; }

        [DisplayName("Realese Date")]
        public DateTime RealeseDate { get; set; }

        [DisplayName("Genre Name")]
        public GenreDTO? GenreName { get; set; }

        public ICollection<ActorAndAdressDTO>? Actors { get; set; }
    }
}
