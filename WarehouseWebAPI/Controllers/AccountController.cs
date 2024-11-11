using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using WarehouseWebAPI.DTOs;
using WarehouseWebAPI.Services;

namespace WarehouseWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService _accountService)
        {
            accountService = _accountService;
        }
        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> SignUp(SignUpDTO signUpDTO)
        {
            try
            {
                var result = await accountService.CreateAccount(signUpDTO);
                if (result)
                {
                    return Ok();
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, "We Have An Issue In User Creation");
                }

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);

            }
        }

        [HttpPost]
        [Route("SignIn")]
        public async Task<IActionResult> SignIn(SignInDTO signInDTO)
        {
            var result = await accountService.Login(signInDTO);
            if (result.Succeeded)
            {
                var user = await accountService.GetUserByName(signInDTO.Username);

                List<Claim> authClaim = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, signInDTO.Username),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim("uniquevalue", Guid.NewGuid().ToString())
        };

                var UserRoles = await accountService.getUserRoles(signInDTO.Username);
                foreach (var role in UserRoles)
                {
                    authClaim.Add(new Claim(ClaimTypes.Role, role));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsALongerSecurityKey12345678"));
                var token = new JwtSecurityToken(
                            issuer: "http://localhost",
                            audience: "User",
                            expires: DateTime.Now.AddDays(15),
                            claims: authClaim,
                            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                            );

                return Ok(new
                {
                    tokenValue = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            else
            {
               return StatusCode(StatusCodes.Status403Forbidden);
            }
        }

        [HttpPost]
        [Route("AddRole")]
        public async Task<IActionResult> AddRole(RoleDTO roleDTO)
        {
            try
            {
                var result = await accountService.AddRole(roleDTO);
                if (result.Succeeded)
                {
                    return StatusCode((int)HttpStatusCode.OK, "Role Added Succesfully");
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, result.Errors);
                }

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetRoles")]
        public async Task<IActionResult> GetRoles()
        {
            return Ok(await accountService.GetRoles());
        }

        [HttpGet]
        [Route("getUserRoles")]

        public async Task<IActionResult> getUserRoles(string username)
        {
            return Ok(await accountService.getUserRoles(username));
        }


        [HttpGet]
        [Route("GetUserInfo")]
        public async Task<IActionResult> GetUserInfo(string username)
        {
            return Ok(await accountService.GetUserByName(username));
        }

        [HttpGet]
        [Route("GetAllUsers")]

        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await accountService.getAllUsers());
        }
    }
}
