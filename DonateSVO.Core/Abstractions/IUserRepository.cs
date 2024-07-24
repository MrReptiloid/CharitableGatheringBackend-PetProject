using DonateSVO.Core.Models;

namespace DonateSVO.Core.Abstractions;

public interface IUserRepository
{
    Task Create(User user);
    Task<User> GetByUserName(string userName);
}
    