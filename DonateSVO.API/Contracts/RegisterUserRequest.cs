using System.ComponentModel.DataAnnotations;

namespace DonateSVO.API.Contracts;

public record RegisterUserRequest(
    [Required] string UserName, 
    [Required] string Password);