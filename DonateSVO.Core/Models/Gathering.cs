namespace DonateSVO.Core.Models;

public class Gathering
{
    private Gathering(
        Guid id, 
        string title, 
        string description, 
        decimal targetAmount, 
        decimal currentAmount,
        int membersCount,
        bool isVerified
    ) {
        Id = id;
        Title = title;
        Description = description;
        TargetAmount = targetAmount;
        CurrentAmount = currentAmount;
        MembersCount = membersCount;
        IsVerified = isVerified;
        CreatedDate = DateTime.UtcNow;
    }
    
    public Guid Id { get; }
    public string Title { get; } = string.Empty;
    public string Description { get; } = String.Empty;
    public DateTime CreatedDate { get; }
    public decimal TargetAmount { get; }
    public decimal CurrentAmount { get; }
    public int MembersCount { get; }
    public bool IsVerified { get; }

    public static (Gathering Gathering, string Error) Create(
        Guid id, 
        string title, 
        string description, 
        decimal targetAmount, 
        decimal currentAmount,
        int membersCount,
        bool isVerified
    ) {
        var error = string.Empty;

        if (string.IsNullOrEmpty(title))
            error = "Title can't be empty";
        
        var gathering = new Gathering(id, title, description, targetAmount, currentAmount, membersCount, isVerified);

        return (gathering, error);
    }
}