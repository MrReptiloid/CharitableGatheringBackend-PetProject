namespace DonateSVO.Core.Abstractions;

public interface IUserService
{
    Task Register(string userName, string password);
    Task<string> Login(string userName, string password);
    Task<bool> Verify(string tokenValue);
}