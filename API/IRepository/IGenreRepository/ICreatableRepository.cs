using API.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.IRepository.IGenreRepository
{
    public interface ICreatableRepository
    {
        Task<ResponseMsg> PostGenre(Genre genre);
    }
}
