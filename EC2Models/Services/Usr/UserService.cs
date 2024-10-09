using EC2Models.DTOs.Usr;
using EC2Models.IRepository.Usr;
using EC2Models.Models;
using EC2Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC2Models.Services.Usr
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDetailDto?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return null;

            var userDto = new UserDetailDto();
            Mapper.CopyProperties(user, userDto);
            return userDto;
        }

        public async Task<IEnumerable<UserListDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(user => {
                var userDto = new UserListDto();
                Mapper.CopyProperties(user, userDto);
                return userDto;
            });
        }

        public async Task AddUserAsync(UserAddDto userDto)
        {
            var user = new Users();
            Mapper.CopyProperties(userDto, user);
            await _userRepository.AddAsync(user);
        }

        public async Task UpdateUserAsync(UserUpdateDto userDto)
        {
            var user = new Users();
            Mapper.CopyProperties(userDto, user);
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<UserDetailDto?> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null) return null;

            var userDto = new UserDetailDto();
            Mapper.CopyProperties(user, userDto);
            return userDto;
        }
    }
}
