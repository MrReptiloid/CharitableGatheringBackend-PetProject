using BCrypt.Net;
using DonateSVO.Application.Interfaces;

namespace DonateSVO.Infrastructure;

public class PasswordHasher : IPasswordHasher
{
    public string Generate(string password) =>
        BCrypt.Net.BCrypt.EnhancedHashPassword(password);

    public bool Verify(string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
    }
}