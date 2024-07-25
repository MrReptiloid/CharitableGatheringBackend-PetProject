using DonateSVO.Core.Models;
using System.IdentityModel.Tokens.Jwt;

namespace DonateSVO.Application.Interfaces;

public interface IJwtProvider
{
    string GenerateToken(User user);
    JwtSecurityToken ToToken(string tokenValyue);
}