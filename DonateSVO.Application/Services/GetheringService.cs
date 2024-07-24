using DonateSVO.Core.Abstractions;
using DonateSVO.Core.Models;

namespace DonateSVO.Services.Services;

public class GatheringService : IGatheringService
{
    private readonly IGatheringsRepository _gatheringsRepository;

    public GatheringService(IGatheringsRepository gatheringsRepository)
    {
        _gatheringsRepository = gatheringsRepository;
    }

    public async Task<List<Gathering>> GetAllGatherings() =>
        await _gatheringsRepository.Get();

    public async Task<Guid> CreateGathering(Gathering gathering) =>
        await _gatheringsRepository.Create(gathering);

    public async Task<Guid> UpdateGathering(
        Guid id,
        string title,
        string description,
        decimal targetAmount,
        decimal currentAmount,
        int membersCount,
        bool isVerified
    ) => 
        await _gatheringsRepository.Update(
            id, 
            title, 
            description, 
            targetAmount,
            currentAmount, 
            membersCount,
            isVerified
        );

    public async Task<Guid> DeleteGathering(Guid id) =>
        await _gatheringsRepository.Delete(id);
}