using AutoMapper;
using Inventario.Services.Contrats;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventario.DataAccess;
using Inventario.Entities.Users;
using Inventario.Entities.Dtos.Users;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Services.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly EncuestasDbContext _context;
        private readonly IMapper _mapper;
        public UserService(UserManager<User> userManager, EncuestasDbContext context, IMapper mapper, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
            _roleManager = roleManager;

        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            List<User> users = await _userManager.Users.ToListAsync();
            List<UserDto> usersDto = new List<UserDto>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var userDto = _mapper.Map<UserDto>(user);
                userDto.Role = roles.FirstOrDefault();

                usersDto.Add(userDto);
            }

            return usersDto;
        }


        public async Task<UserDto> GetUserAsync(string id)
        {
            User user = await _userManager.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            var roles = await _userManager.GetRolesAsync(user);

            UserDto userDto = _mapper.Map<UserDto>(user);
            userDto.Role = roles.FirstOrDefault();

            return userDto;
        }

        public async Task<IdentityResult> AddUserAsync(NewUserDto userDto)
        {
            var roleExists = await _roleManager.RoleExistsAsync("user");

            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole("user"));
            }

            var user = new User
            {
                NormalizedUserName = userDto.Username,
                UserName = userDto.Username,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
            };

            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "user");
            }

            return result;
        }

        public async Task<IdentityResult> AddUserAdminAsync(NewUserDto userDto)
        {
            var roleExists = await _roleManager.RoleExistsAsync("admin");

            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole("admin"));
            }

            var user = new User
            {
                NormalizedUserName = userDto.Username,
                UserName = userDto.Username,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
            };

            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "admin");
            }

            return result;
        }

        public async Task EditUserAsync(string id, EditUserDto userDto)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                user.FirstName = userDto.FirstName;
                user.LastName = userDto.LastName;
                user.UserName = userDto.Username;
                user.NormalizedUserName = user.NormalizedUserName;
                if (!string.IsNullOrEmpty(userDto.Password))
                {
                    var newPasswordHash = _userManager.PasswordHasher.HashPassword(user, userDto.Password);
                    user.PasswordHash = newPasswordHash;
                }
            }
            await _context.SaveChangesAsync();
        }


        public async Task DeleteUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    var roles = await _userManager.GetRolesAsync(user);

                    if (roles != null && roles.Any())
                    {
                        foreach (var role in roles)
                        {
                            await _userManager.RemoveFromRoleAsync(user, role);
                        }
                    }
                }
            }
        }

        public async Task<string> GetUserRoleAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user != null)
            {
                var roles = await _userManager.GetRolesAsync(user);
                return roles.FirstOrDefault();
            }

            return null;
        }


    }
}
