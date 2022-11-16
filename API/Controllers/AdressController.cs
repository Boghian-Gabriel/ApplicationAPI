using API.IRepository;
using API.Model;
using API.ModelsDTO.ActorAdrDto;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers
{
    #region "ActorAdressController class"
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdressController : ControllerBase
    {
        #region "Properties"
        private readonly IActorAdressRepository _actorAdressRepository;
        private readonly IActorRepository _actorRepository;
        private readonly IMapper _mapper;
        #endregion

        #region "Constructor"
        public AdressController(IActorAdressRepository actorAdressRepository, IActorRepository actorRepository, IMapper mapper)
        {
            _actorAdressRepository = actorAdressRepository;
            _actorRepository = actorRepository;
            _mapper = mapper;
        }
        #endregion

        #region "Gel All ActorAdress"
        [SwaggerOperation(Summary = "Fetches an adress list")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActorAdressDTO>>> GetAdress()
        {
            try
            {
                var results = await _actorAdressRepository.GetActorAdress();
                if (results != null)
                {
                    var resMapper = _mapper.Map<IEnumerable<ActorAdressDTO>>(results);
                    return Ok(resMapper);
                }
                else
                {
                    return NotFound("There is no information");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database" + ex);
            }
        }
        #endregion

        #region "GetActorAdressById"
        [SwaggerOperation(Summary = "Fetches an adress by Id")]
        [HttpGet("{actorAdressId}")]
        public async Task<ActionResult<ActorAdressDTO>> GetAdressById(Guid actorAdressId)
        {
            try
            {
                var result = await _actorAdressRepository.GetActorAdressById(actorAdressId);
                if (result != null)
                {
                    var resActAdrMapper = _mapper.Map<ActorAdressDTO>(result);
                    return Ok(resActAdrMapper);
                }
                else
                {
                    return NotFound($"The ActorAdress with id: ' {actorAdressId} ' was not found!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database" + ex);
            }
        }
        #endregion

        #region "GetActorAdressByZipCode"
        [SwaggerOperation(Summary = "Fetches an adress by ZipCode")]
        [HttpGet("zipCode")]
        public async Task<ActionResult<ActorAdressDTO>> GetAdressByZipCode(int zipCode)
        {
            try
            {
                var result = await _actorAdressRepository.GetActorAdressByZipCode(zipCode);
                if (result != null)
                {
                    var resMapper = _mapper.Map<ActorAdressDTO>(result);
                    return Ok(resMapper);
                }
                else
                {
                    return NotFound($"The ActorAdress with zipCode: ' {zipCode} ' was not found!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database" + ex);
            }

        }
        #endregion

        #region "PostActorAdress"
        [SwaggerOperation(Summary = "Create an adress")]
        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<ActorAdressDTO>> PostAdress(InsertActorAdressWithActorID actorAdrDto)
        {
            try
            {
                var existIdInActor = await _actorRepository.GetActorById(actorAdrDto.ActorAdressId);
                if (existIdInActor == null)
                {
                    return BadRequest(new ResponseMsg
                    {
                        isSuccess = false,
                        Message = $"The id: '{actorAdrDto.ActorAdressId}' was not found in the Actor table to make the association with an actor."
                    });
                }
                var actorAdress = _mapper.Map<ActorAdress>(actorAdrDto);
                var result = await _actorAdressRepository.PostActorAdress(actorAdress);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error" + ex.Message);
            }
        }
        #endregion

        #region "UpdateActorAdress"
        [SwaggerOperation(Summary = "Update an adress")]
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateAdress(Guid id, UpdateActorAdressDTO actorAdrDTO)
        {
            try
            {
                if (id != actorAdrDTO.ActorAdressId)
                {
                    return BadRequest(new ResponseMsg
                    {
                        isSuccess = false,
                        Message = $"The id: '{id}' and id:'{actorAdrDTO.ActorAdressId}'  are not the same!"
                    });
                }

                var actorAdr = _mapper.Map<ActorAdress>(actorAdrDTO);
                if (actorAdr != null)
                {
                    var result = await _actorAdressRepository.UpdateActorAdress(id, actorAdr);
                    return Ok(new ResponseMsg
                    {
                        isSuccess = true,
                        Message = "The information has been successfully updated"
                    });
                }
                else
                {
                    return NotFound($"The ActorAdress with id: ' {id} ' was not found!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                   "Error" + ex);
            }
        }
        #endregion

        #region "Delete"
        [SwaggerOperation(Summary = "Delete an adress")]
        [HttpDelete("{id}")]
        [Authorize(Roles = UserRole.Administrator)]
        public async Task<IActionResult> DeleteAdress(Guid id)
        {
            try
            {
                var result = await _actorAdressRepository.GetActorAdressById(id);

                if (result == null)
                {
                    return NotFound($"ActorAdress with Id: ' {id} ' not found!");
                }

                await _actorAdressRepository.DeleteActorAdress(id);

                return Ok($"ActorAdress with Id: ' {id} ' is deleted!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error" + ex.Message);
            }

        }
        #endregion
    }
    #endregion
}
