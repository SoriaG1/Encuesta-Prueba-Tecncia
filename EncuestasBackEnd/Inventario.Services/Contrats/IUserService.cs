using Inventario.Entities.Dtos.Users;
using Inventario.Entities.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Services.Contrats
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsersAsync();
        Task<UserDto> GetUserAsync(string id);
        Task<IdentityResult> AddUserAsync(NewUserDto userDto);
        Task<IdentityResult> AddUserAdminAsync(NewUserDto userDto);
        Task EditUserAsync(string id, EditUserDto userDto);
        Task DeleteUserAsync(string id);
        Task<string> GetUserRoleAsync(string username);
    }
}
