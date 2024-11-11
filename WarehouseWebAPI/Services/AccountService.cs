using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WarehouseWebAPI.Data;
using WarehouseWebAPI.DTOs;

namespace WarehouseWebAPI.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountService(UserManager<ApplicationUser> _userManager,
            SignInManager<ApplicationUser> _signInManager
            , RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
        }

        public async Task<bool> CreateAccount(SignUpDTO signUpDTO)
        {
            bool IsSuccess = true;
            ApplicationUser newUser = new ApplicationUser()
            {
                UserName = signUpDTO.UserName,
                Email = signUpDTO.Email,
                Name = signUpDTO.Name,
                WarehouseId = signUpDTO.WarehouseId
            };

            var createUserResult = await userManager.CreateAsync(newUser, signUpDTO.Password);// To save hashed password
            if (createUserResult.Succeeded)
            {
                var RoleResult = await userManager.AddToRoleAsync(newUser, signUpDTO.RoleName);
                if (!RoleResult.Succeeded)
                {
                    await userManager.DeleteAsync(newUser);
                    IsSuccess = false;
                }

            }
            else
            {
                IsSuccess = false;
            }
            return IsSuccess;
        }

        public async Task<SignInResult> Login(SignInDTO signInDTO)
        {
            var result = await signInManager.PasswordSignInAsync(signInDTO.Username, signInDTO.Password, false, false);
            return result;
        }

        public async Task<IdentityResult> AddRole(RoleDTO roleDTO)
        {
            IdentityRole newRole = new IdentityRole()
            {
                Name = roleDTO.Name
            };
            return await roleManager.CreateAsync(newRole);
        }

        public async Task<IList<string>> getUserRoles(string username)
        {
            var user = await userManager.FindByNameAsync(username);

            return await userManager.GetRolesAsync(user);
        }

        public async Task<List<RoleDTO>> GetRoles()
        {
            var roles = await roleManager.Roles.ToListAsync();
            List<RoleDTO> AllRoles = new List<RoleDTO>();
            foreach (var role in roles)
            {
                AllRoles.Add(new RoleDTO()
                {
                    Id = role.Id,
                    Name = role.Name
                });
            }
            return AllRoles;
        }

        public async Task<ApplicationUser> GetUserByName(string username)
        {
            var result = await userManager.FindByNameAsync(username);
            return result;
        }

      

        public async Task<List<ApplicationUserDto>> getAllUsers()
        {
            var allUsers = await userManager.Users.ToListAsync();
            List<ApplicationUserDto> users = new List<ApplicationUserDto>();
            
            foreach (var user in allUsers)
            {
                users.Add(new ApplicationUserDto()
                {
                    Name = user.Name,
                    UserName = user.UserName,
                    Email = user.Email,
                    RoleName = await userManager.GetRolesAsync(user),
                    WarehouseId = user.WarehouseId,
                });
            }
            return users;
        }

    }
}
