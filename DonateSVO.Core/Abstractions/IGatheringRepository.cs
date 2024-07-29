using DonateSVO.Core.Models;

namespace DonateSVO.Core.Abstractions;

public interface IGatheringRepository
{
    Task<Guid> Create(Gathering gathering);
    Task<Guid> Delete(Guid id);
    Task<List<Gathering>> Get();

    Task<Guid> Update(
        Guid id,
        string title, 
        string description, 
        decimal targetAmount, 
        decimal currentAmount,
        int membersCount,
        bool isVerified
    );
}