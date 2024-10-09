using EC2Models.Models;

namespace EC2Models.IRepository.Usr
{
    public interface IUserRepository : IRepository<Users>
    {
        Task<Users?> GetUserByEmailAsync(string email);
    }

}
