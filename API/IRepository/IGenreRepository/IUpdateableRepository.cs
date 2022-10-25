using API.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.IRepository.IGenreRepository
{
    public interface IUpdateableRepository
    {
        Task<IActionResult> UpdateGenre(Guid id, Genre genre);
    }
}
