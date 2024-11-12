using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using WarehouseWebAPI.Data;
using WarehouseWebAPI.DTOs;

namespace WarehouseWebAPI.Services
{
    public interface IAccountService
    {
        Task<bool> CreateAccount(SignUpDTO signUpDTO);
        Task<SignInResult> Login(SignInDTO signInDTO);
        Task<IdentityResult> AddRole(RoleDTO roleDTO);
        Task<IList<string>> getUserRoles(string username);
        Task<List<RoleDTO>> GetRoles();

        Task<ApplicationUser> GetUserByName(string username);
        Task<List<ApplicationUserDto>> getAllUsers();
        Task<bool> DeleteUserByName(string username);
        Task<ApplicationUserDto> getUser(string userName);
        Task<IdentityResult> UpdateUser(ApplicationUserDto userDTO);
    }
}