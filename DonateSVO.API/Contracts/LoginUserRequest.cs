using System.ComponentModel.DataAnnotations;

namespace DonateSVO.API.Contracts;

public record LoginUserRequest(
    [Required] string UserName, 
    [Required] string Password);