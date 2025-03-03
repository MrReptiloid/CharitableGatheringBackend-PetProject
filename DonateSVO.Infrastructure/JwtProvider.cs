﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DonateSVO.Application.Interfaces;
using DonateSVO.Core.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DonateSVO.Infrastructure;

public class JwtProvider(IOptions<JwtOptions> options) : IJwtProvider
{
    private readonly JwtOptions _options = options.Value;

    public string GenerateToken(User user)
    {
        Claim[] claims =
        [
            new("userId", user.Id.ToString()),
            new("userName", user.UserName)
        ];
        
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
            SecurityAlgorithms.HmacSha256);
        
        var token = new JwtSecurityToken(
            claims: claims,
            signingCredentials: signingCredentials,
            expires: DateTime.UtcNow.AddHours(_options.ExpiresHours));

        var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
        return tokenValue;
    }

    public JwtSecurityToken ToToken(string tokenValue)
    {
        return new JwtSecurityTokenHandler().ReadJwtToken(tokenValue);
    }
}