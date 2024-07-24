namespace DonateSVO.API.Contracts;

public record GatheringsResponse(
    Guid Id,
    string Title,
    string Description,
    DateTime CreatedDate,
    decimal TargetAmount, 
    decimal CurrentAmount,
    int MembersCount,
    bool IsVerified
);