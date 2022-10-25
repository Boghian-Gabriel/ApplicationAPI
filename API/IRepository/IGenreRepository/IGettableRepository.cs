using API.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.IRepository.IGenreRepository
{
    public interface IGettableRepository
    {
        Task<IEnumerable<Genre>> GetGenres();
        Task<Genre> GetGenreById(Guid id);
        Task<Genre> SearchGenreByName(string name);
        Task<Genre> GetGenreByName(string name);
        Task<Genre> GetGenreWithMovies(Guid id);
    }
}
