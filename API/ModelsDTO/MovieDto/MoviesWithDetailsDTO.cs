using API.ModelsDTO.ActorDto;
using API.ModelsDTO.GenreDto;
using System.ComponentModel;

namespace API.ModelsDTO.MovieDto
{
    public class MoviesWithDetailsDTO
    {
        [DisplayName("Movie Title")]
        public string? Title { get; set; }
        public DateTime RealeseDate { get; set; }

        [DisplayName("Movie Title")]
        public GenreDTO? GenreName { get; set; }

        public ICollection<ActorAndAdressDTO>? Actors { get; set; }
    }
}
