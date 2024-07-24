using System.Net.Sockets;
using DonateSVO.Application.Interfaces;
using DonateSVO.Core.Abstractions;
using DonateSVO.Core.Models;

namespace DonateSVO.Services.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtProvider _jwtProvider;

    public UserService(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IJwtProvider jwtProvider)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtProvider = jwtProvider;
    }
    
    public async Task Register(string userName, string password)
    {
        var hashedPassword = _passwordHasher.Generate(password);

        var user = User.Create(Guid.NewGuid(), userName, hashedPassword);

        await _userRepository.Create(user);
    }

    public async Task<string> Login(string userName, string password)
    {
        var user = await _userRepository.GetByUserName(userName);
        
        var result = _passwordHasher.Verify(password, user.PasswordHash);

        if (!result)
            throw new Exception($"Failed to login: {userName}");

        var token = _jwtProvider.GenerateToken(user);
        
        return token;
    }
}