using EC2Models.IRepository.Usr;
using EC2Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
namespace EC2Models.Repository.Usr
{
    public class UserRepository : Repository<Users>, IUserRepository
    {
        public UserRepository(EC2Context context) : base(context)
        {
        }

        public async Task<Users?> GetUserByEmailAsync(string email)
            => await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
    }

}
