using DonateSVO.API.Contracts;
using DonateSVO.Core.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace DonateSVO.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController: ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [Route("register")]
    [HttpPost]
    public async Task<ActionResult> Register(RegisterUserRequest request)
    {
        await _userService.Register(request.UserName, request.Password);

        return Ok();
    }
    
    [Route("login")]  
    [HttpPost]
    public async Task<ActionResult> Login(LoginUserRequest request)
    {
        var token = string.Empty;
        try
        {
            token  = await _userService.Login(request.UserName, request.Password);
        }
        catch (Exception e)
        {
            return UnprocessableEntity(e.Message);
        }
        
        HttpContext.Response.Cookies.Append("tasty-cookies", token);
        
        return Ok(token);
    }

    [Route("verify")]
    [HttpGet]
    public async Task<IActionResult> Verify()
    {
        var tokenValue = HttpContext.Request.Cookies["tasty-cookies"];

        var result = await _userService.Verify(tokenValue);

        if (!result)
            return Unauthorized();
        
        return Ok(result);
    }
    
}