using DonateSVO.Core.Abstractions;
using DonateSVO.Core.Models;
using DonateSVO.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DonateSVO.DataAccess.Repository;

public class UserRepository : IUserRepository
{
    private readonly DonateSvoDbContext _context;

    public UserRepository(DonateSvoDbContext context)
    {
        _context = context;
    }

    public async Task Create(User user)
    {
        var userEntity = new UserEntity()
        {
            Id = user.Id,
            UserName = user.UserName,
            PasswordHash = user.PasswordHash
        };

        await _context.Users.AddAsync(userEntity);
        await _context.SaveChangesAsync();
    }

    public async Task<User> GetByUserName(string userName)
    {
        var userEntities = await _context.Users
            .AsNoTracking()
            .ToListAsync();

        var userEntity = userEntities
            .FirstOrDefault(u => u.UserName == userName) ?? throw new Exception();
 
        return User.Create(
            userEntity.Id,
            userEntity.UserName,
            userEntity.PasswordHash
        );
    }
}