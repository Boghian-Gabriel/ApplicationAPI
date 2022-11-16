using API.Context;
using API.IRepository;
using API.Model;
using API.ModelsDTO.UserDto;
using API.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System.Data.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    #region "AuthenticationController class"
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public AuthenticationController(
                IConfiguration configuration, 
                ContextDB context, 
                IMapper mapper,
                IUserRepository userRepository)
        {
            _configuration = configuration;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        #region "Login"
        [SwaggerOperation(Summary = "Login")]
        [HttpPost]
        public async Task<ActionResult<UserLoginDTO>> Login(UserLoginDTO userLogDTO)
        {
            ResponseMsg resposne = new ResponseMsg();
            try
            {
                var searchUserByEmail = await _userRepository.GetUserByEmail(userLogDTO.Email);

                if (searchUserByEmail == null)
                {
                    return BadRequest($"The username with email: {userLogDTO.Email} does not exists");
                }

                var searchUserByEmailisActive = await _userRepository.GetUserByEmailIsActive(userLogDTO.Email);
                if (searchUserByEmailisActive == null)
                {
                    return BadRequest($"The username with email: {userLogDTO.Email} is inactive");
                }

                var user = _mapper.Map<User>(userLogDTO);
                var validateUser = await _userRepository.Login(user);
                if (validateUser == null)
                {
                    return BadRequest("Email, password or role is incorrect or not exist");
                }

                var token = this.getToken(user);

                return Ok(new
                {
                    succes = resposne.isSuccess = true,
                    message = resposne.Message = $"Login successfully. You are logged in as: '{searchUserByEmail.UserRole}'",
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    email = userLogDTO.Email,
                    expire = token.ValidTo
                }); ;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error " + ex.Message);
            }
        }
        #endregion

        #region "Register"
        [SwaggerOperation(Summary = "Register")]
        [HttpPost]
        public async Task<ActionResult<UserRegistrationDTO>> Register(UserRegistrationDTO userRegDTO)
        {
            try
            {
                var existUserEmail = await _userRepository.GetUserByEmail(userRegDTO.Email);
                if (existUserEmail != null)
                {
                    return BadRequest($"User with email: '{userRegDTO.Email}' is already exists");
                }
                else
                {
                    var user = _mapper.Map<User>(userRegDTO);
                    await _userRepository.Register(user);
                    return Ok(new ResponseMsg { isSuccess = true, Message = "User is successfully registered"});
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error" + ex.Message);
            }
        }
        #endregion

        #region "Get all users"
        [SwaggerOperation(Summary = "Fetches an user list")]
        [HttpGet]
        [Authorize(Roles = UserRole.Administrator)]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            try
            {
                var users = await _userRepository.GetUsers();

                if (users != null)
                {
                    var userMapper = _mapper.Map<IEnumerable<UserDTO>>(users);
                    return Ok(userMapper);
                }
                else
                {
                    return BadRequest("There is no infromation");
                }
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error " + ex.Message);
            }
        }
        #endregion

        #region "Get all users active/inactive "
        [SwaggerOperation(Summary = "Fetches an (active/inactive) user list")]
        [HttpGet("isActive")]
        [Authorize(Roles = UserRole.Administrator)]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsersActiveInactive(bool isActive = true )
        {
            try
            {
                var users = await _userRepository.GetUsersActiveInactive(isActive);

                if (users != null)
                {
                    var userMapper = _mapper.Map<IEnumerable<UserDTO>>(users);
                    return Ok(userMapper);
                }
                else
                {
                    return BadRequest("There is no infromation");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error " + ex.Message);
            }
        }
        #endregion

        #region "Get user by id"
        [SwaggerOperation(Summary = "Fetches an user by Id")]
        [HttpGet("{userId}")]
        [Authorize(Roles = UserRole.Administrator)]
        public async Task<ActionResult<UserDTO>> GetUserById(int userId)
        {
            try
            {
                //GET THE INFORMATION FROM THE DATABASE!
                var result = await _userRepository.GetUserById(userId);
                if (result != null)
                {
                    //I map to the GenreDTO table to provide to the client
                    var resUserMapper = _mapper.Map<UserDTO>(result);
                    return Ok(resUserMapper);
                }
                else
                {
                    return NotFound($"The user with id: ' {userId} ' was not found!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error " + ex.Message);
            }
        }
        #endregion

        #region "Search information by email field"
        [SwaggerOperation(Summary = "Search user by email")]
        [HttpGet("email")]
        [Authorize(Roles = UserRole.Administrator)]
        public async Task<ActionResult<UserDTO>> SearchUserByEmail(string email)
        {
            try
            {
                var searchUser = await _userRepository.GetUserByEmail(email);

                if (searchUser == null)
                {
                    return BadRequest($"User with email: '{email}' was not found");
                }

                var result = _mapper.Map<UserDTO>(searchUser);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error " + ex.Message);
            }
        }
        #endregion

        #region "Search role by email field"
        [SwaggerOperation(Summary = "Fetches an user by role(User or Administrator)")]
        [HttpGet("search")]
        [Authorize(Roles = UserRole.Administrator)]
        public async Task<ActionResult<UserRoleDTO>> GetUserRoleByEmail(string email)
        {
            try
            {
                var searchUser = await _userRepository.GetUserByEmail(email);

                if (searchUser == null)
                {
                    return BadRequest($"User with email: '{email}' was not found");
                }

                var result = _mapper.Map<UserRoleDTO>(searchUser);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error " + ex.Message);
            }
        }
        #endregion

        #region "Update User"
        [SwaggerOperation(Summary = "Update an user")]
        [HttpPut("{id}")]
        [Authorize(Roles = UserRole.Administrator)]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserDTO userUpdateDTO)
        {
            try
            {
                if (id != userUpdateDTO.UserId)
                {
                    return BadRequest($"The ids are not the same: {id} != {userUpdateDTO.UserId}");
                }
                var existUser = await _userRepository.GetUserById(id);
                if (existUser != null)
                {

                    var user = _mapper.Map<User>(userUpdateDTO);
                    await _userRepository.Update(user);
                    return Ok("User is successfully updated");
                }
                else
                {
                    return NotFound($"The user with id: ' {id} ' was not found!");
                }

            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error " + ex.Message);
            }
        }
        #endregion

        #region "Delete User"
        [SwaggerOperation(Summary = "Delete an user")]
        [HttpDelete("{userId}")]
        [Authorize(Roles = UserRole.Administrator)]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            try
            {
                var result = await _userRepository.GetUserById(userId);

                if (result == null)
                {
                    return NotFound($"User with Id: ' {userId} ' not found!");
                }

                await _userRepository.DeleteUser(userId);

                return Ok($"Movie with Id: ' {userId} ' is deleted!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error" + ex.Message);
            }
        }
        #endregion

        #region "Generate token with user"
        private JwtSecurityToken getToken(User user)
        {
            var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
            
            var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Id", user.UserId.ToString()),
                        //new Claim("UserName", user.UserName),
                        new Claim("Password", user.Email),
                        new Claim("Email", user.Password),
                        new Claim(ClaimTypes.Role, user.UserRole)
                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                        jwt.Issuer,
                        jwt.Audience,
                        claims,
                        expires: DateTime.Now.AddMinutes(20),
                        signingCredentials: signIn
                        );

            return token;
        }
        #endregion
    }
    #endregion
}
