using System.Data.Common;

namespace DonateSVO.Core.Models;

public class User
{
    private User(Guid id, string userName, string passwordHash)
    {
        Id = id;
        UserName = userName;
        PasswordHash = passwordHash;
    }
    
    public Guid Id { get; }
    public string UserName { get; private set; }
    public string PasswordHash { get; private set; }

    public static User Create(Guid id, string userName, string passwordHash)
    {
        return new User(id, userName, passwordHash);
    }
}