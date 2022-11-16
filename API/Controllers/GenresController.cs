using API.Model;
using API.Repository;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using API.ModelsDTO.GenreDto;
using Microsoft.AspNetCore.Authorization;
using API.IRepository.IGenreRepository;
using Swashbuckle.AspNetCore.Annotations;
using Newtonsoft.Json;

namespace API.Controllers
{
    #region "GenresControler class"
    [Route("api/[controller]/[Action]")]
    //[Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        #region "Properties"
        private readonly ICreatableRepository _genreCreateableRepository;
        private readonly IGettableRepository _genreGettableRepository;
        private readonly IUpdateableRepository _genreUpdateableRepository;
        private readonly IDeleteableRepository _genreDeleteableRepository;
        private readonly IMapper _mapper;
        #endregion

        #region "Constructor"
        public GenresController(
                ICreatableRepository genreCreateableRepository, 
                IMapper mapper,
                IGettableRepository genreGettableRepository,
                IUpdateableRepository genreUpdateableRepository,
                IDeleteableRepository genreDeleteableRepository
            )
        {
            _genreCreateableRepository = genreCreateableRepository;
            _mapper = mapper;
            _genreGettableRepository = genreGettableRepository;
            _genreUpdateableRepository = genreUpdateableRepository;
            _genreDeleteableRepository = genreDeleteableRepository;
        }
        #endregion

        #region "GetAllGenres"
        [SwaggerOperation(Summary = "Fetches a genres list")]
        [HttpGet]
        public async Task<ActionResult<GenreDTO>> GetAllGenres()
        {
            try
            {
                var results = await _genreGettableRepository.GetGenres();
                if (results != null)
                {
                    var resMapper = _mapper.Map<IEnumerable<GenreDTO>>(results);
                    return Ok(resMapper);
                }
                else
                {
                    return NotFound();
                }

            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database" + ex);
            }
            
        }
        #endregion

        #region "GetGenreById"
        [SwaggerOperation(Summary = "Fetches a genre")]
        [HttpGet("{genreId}")]
        public async Task<ActionResult<GenreNameDTO>> GetGenreById(Guid genreId)
        {
            try
            {
                //GET THE INFORMATION FROM THE DATABASE!
                var result = await _genreGettableRepository.GetGenreById(genreId);

                if (result != null)
                {
                    //I map to the GenreDTO table to provide to the client
                    var resGenreMapper = _mapper.Map<GenreNameDTO>(result);
                    return Ok(resGenreMapper);
                }
                else
                {
                    return NotFound($"The genre with id: ' {genreId} ' was not found!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database" + ex);
            }
        }
        #endregion

        #region "GetGenreByName"
        [SwaggerOperation(Summary = "Fetches a genre by name")]
        [HttpGet("genreName")]
        public async Task<ActionResult<GenreNameDTO>> GetGenreByName(string genreName)
        {
            try
            {
                var result = await _genreGettableRepository.SearchGenreByName(genreName);
                if(result != null) 
                {
                    var resGenreMapper = _mapper.Map<GenreNameDTO>(result);
                    return Ok(resGenreMapper); 
                } else
                {
                    return NotFound($"The genre with name: ' {genreName} ' was not found!");
                }
                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database" + ex);
            }
        }
        #endregion

        #region "GetGenreWithMovies"
        [SwaggerOperation(Summary = "Fetches a genre with movies list")]
        [HttpGet("{genreId}")]
        //[Route("GetGenreWithDetails")]
        public async Task<ActionResult<GenreWithMovieDTO>> GetGenreWithMovies(Guid genreId)
        {
            try
            {
                var results = await _genreGettableRepository.GetGenreWithMovies(genreId);
                if (results != null)
                {
                    var resGenreMapper = _mapper.Map<GenreWithMovieDTO>(results);
                    return Ok(resGenreMapper);
                }
                else
                {
                    return NotFound($"The genres was not found!");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database" + ex);
            }
        }
        #endregion

        #region "PostGenre"
        [SwaggerOperation(Summary = "Create a genre")]
        [HttpPost]
        public async Task<ActionResult> PostGenre(GenreDTO genreDTO)
        {
            ResponseMsg response = new ResponseMsg();
            try
            {
                var existGenre = await _genreGettableRepository.GetGenreByName(genreDTO.GenreName);

                if(existGenre != null)
                {
                    ModelState.AddModelError("GenreName", "The genre name already exists");
                    return BadRequest(ModelState);
                }

                var genre = _mapper.Map<Genre>(genreDTO);
                //or manually mapper 
                //var genre = new Genre();
                //genre.GenreName = genreDTO.GenreName;

                response = await _genreCreateableRepository.PostGenre(genre);
            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }
        #endregion

        #region "UpdateGenre"
        [HttpPut("{genreId}")]
        [SwaggerOperation(Summary = "Update a genre")]
        //[Authorize(Roles = UserRole.User)]
        [Authorize]
        public async Task<IActionResult> UpdateGenre(Guid genreId, UpdateGenreDTO genreDTO)
        {
            try
            {
                if(genreId != genreDTO.IdGenre)
                {
                    ModelState.AddModelError("Id", $"The id: '{genreId}' and id:'{genreDTO.IdGenre}'  are not the same!");
                    return BadRequest(ModelState);
                }

                var genre = _mapper.Map<Genre>(genreDTO);
                if (genre != null)
                {
                    var result = await _genreUpdateableRepository.UpdateGenre(genre.IdGenre, genre);
                    return StatusCode(StatusCodes.Status200OK, "The information has been updated");
                }
                else
                {
                    return NotFound($"The genres with id: ' {genreId} ' was not found!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error" + ex);
            }
        }
        #endregion

        #region "Delete"
        [SwaggerOperation(Summary = "Delete a genre")]
        [HttpDelete("{genreId}")]
        [Authorize(Roles = UserRole.Administrator)]
        public async Task<IActionResult> DeleteGenre(Guid genreId)
        {
            try
            {
                var resultIdToDelete = await _genreGettableRepository.GetGenreById(genreId);

                if (resultIdToDelete == null)
                {
                    return NotFound($"Genre with Id: ' {genreId} ' not found!");
                }
                await _genreDeleteableRepository.DeleteGenre(genreId);

                return Ok($"Genre with Id: ' {genreId} ' is deleted!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Error" + ex.Message);
            }
        }
        #endregion     
    }
    #endregion
}
