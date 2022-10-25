using API.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.IRepository.IGenreRepository
{
    public interface IDeleteableRepository
    {
        Task DeleteGenre(Guid id);
    }
}
