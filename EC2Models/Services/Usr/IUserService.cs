using EC2Models.DTOs.Usr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC2Models.Services.Usr
{
    public interface IUserService
    {
        Task<UserDetailDto?> GetUserByIdAsync(int id);
        Task<IEnumerable<UserListDto>> GetAllUsersAsync();
        Task AddUserAsync(UserAddDto userDto);
        Task UpdateUserAsync(UserUpdateDto userDto);
        Task DeleteUserAsync(int id);
        Task<UserDetailDto?> GetUserByEmailAsync(string email);
    }

}
