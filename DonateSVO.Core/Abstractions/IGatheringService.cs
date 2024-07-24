using DonateSVO.Core.Models;

namespace DonateSVO.Core.Abstractions;

public interface IGatheringService
{
    Task<List<Gathering>> GetAllGatherings();
    Task<Guid> CreateGathering(Gathering gathering);
    Task<Guid> DeleteGathering(Guid id);
    Task<Guid> UpdateGathering(
        Guid id,
        string title,
        string description,
        decimal targetAmount,
        decimal currentAmount,
        int membersCount,
        bool isVerified
    );
}