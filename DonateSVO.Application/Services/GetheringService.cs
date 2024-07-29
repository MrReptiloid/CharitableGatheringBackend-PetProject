using DonateSVO.Core.Abstractions;
using DonateSVO.Core.Models;

namespace DonateSVO.Services.Services;

public class GatheringService : IGatheringService
{
    private readonly IGatheringRepository _gatheringRepository;

    public GatheringService(IGatheringRepository gatheringRepository)
    {
        _gatheringRepository = gatheringRepository;
    }

    public async Task<List<Gathering>> GetAllGatherings() =>
        await _gatheringRepository.Get();

    public async Task<Guid> CreateGathering(Gathering gathering) =>
        await _gatheringRepository.Create(gathering);

    public async Task<Guid> UpdateGathering(
        Guid id,
        string title,
        string description,
        decimal targetAmount,
        decimal currentAmount,
        int membersCount,
        bool isVerified
    ) => 
        await _gatheringRepository.Update(
            id, 
            title, 
            description, 
            targetAmount,
            currentAmount, 
            membersCount,
            isVerified
        );

    public async Task<Guid> DeleteGathering(Guid id) =>
        await _gatheringRepository.Delete(id);
}