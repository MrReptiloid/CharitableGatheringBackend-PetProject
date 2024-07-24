using DonateSVO.Core.Abstractions;
using DonateSVO.Core.Models;
using DonateSVO.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DonateSVO.DataAccess.Repository;

public class GatheringsRepository : IGatheringsRepository
{
    private readonly DonateSvoDbContext _context;
        
    public GatheringsRepository(DonateSvoDbContext context)
    {
        _context = context;
    }

    public async Task<List<Gathering>> Get()
    {
        var gatheringEntities = await _context.Gatherings
            .AsNoTracking()
            .ToListAsync();

        var gatherings = gatheringEntities
            .Select(g => Gathering.Create(
                g.Id,
                g.Title,
                g.Description,
                g.TargetAmount,
                g.CurrentAmount,
                g.MembersCount,
                g.IsVerified
            ).Gathering)
            .ToList();

        return gatherings;
    }
    
    public async Task<Guid> Create(Gathering gathering)
    {
        var gatheringEntity = new GatheringEntity
        {
            Id = gathering.Id,
            Title = gathering.Title,
            Description = gathering.Description,
            TargetAmount = gathering.TargetAmount,
            CurrentAmount = gathering.CurrentAmount,
            MembersCount = gathering.MembersCount,
            IsVerified = gathering.IsVerified        
        };

        await _context.Gatherings.AddAsync(gatheringEntity);
        await _context.SaveChangesAsync();

        return gatheringEntity.Id;
    }

    public async Task<Guid> Update(
        Guid id,
        string title, 
        string description,
        decimal targetAmount, 
        decimal currentAmount,
        int membersCount,
        bool isVerified
    ) {
        await _context.Gatherings
            .Where(g => g.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(g => g.Title, g => title)
                .SetProperty(g => g.Description, g => description)
                .SetProperty(g => g.TargetAmount, g => targetAmount)
                .SetProperty(g => g.CurrentAmount, g => currentAmount)
                .SetProperty(g => g.MembersCount, g => membersCount)
                .SetProperty(g => g.IsVerified, g => isVerified)
            );

        return id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        await _context.Gatherings
            .Where(g => g.Id == id)
            .ExecuteDeleteAsync();

        return id;
    }
}