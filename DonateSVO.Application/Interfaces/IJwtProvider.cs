using DonateSVO.Core.Models;

namespace DonateSVO.Application.Interfaces;

public interface IJwtProvider
{
    string GenerateToken(User user);
}