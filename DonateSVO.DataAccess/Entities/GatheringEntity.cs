namespace DonateSVO.DataAccess.Entities;

public class GatheringEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = String.Empty;
    public DateTime CreatedDate { get; set; }
    public decimal TargetAmount { get; set; }
    public decimal CurrentAmount { get; set; }
    public int MembersCount { get; set; }
    public bool IsVerified { get; set; }
}