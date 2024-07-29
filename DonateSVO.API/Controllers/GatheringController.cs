using DonateSVO.API.Contracts;
using DonateSVO.Core.Abstractions;
using DonateSVO.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DonateSVO.API.Controllers;

[ApiController]
[Route("[controller]")]
public class GatheringController : ControllerBase
{
    private readonly IGatheringService _gatheringService;
    
    public GatheringController(IGatheringService gatheringService)
    {
        _gatheringService = gatheringService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Gathering>>> GetGatherings()
    {
        var gatherings = await _gatheringService.GetAllGatherings();

        var response = gatherings.Select(g => new GatheringsResponse(
            g.Id,
            g.Title,
            g.Description,
            g.CreatedDate,
            g.TargetAmount,
            g.CurrentAmount,
            g.MembersCount,
            g.IsVerified
        ));
        
        
        return Ok(response);
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Guid>> CreateGathering([FromBody] GatheringsRequest request)
    {  
        var (gathering, error) = Gathering.Create(
            Guid.NewGuid(),
            request.Title,
            request.Description,
            request.TargetAmount,
            request.CurrentAmount,
            request.MembersCount,
            request.IsVerified
        );

        if (!string.IsNullOrEmpty(error))
        {
            return BadRequest(error);
        }

        var gatheringId = await _gatheringService.CreateGathering(gathering);
    
        return Ok(gatheringId);
    }

    [HttpPut("{id:guid}")]
    [Authorize]
    public async Task<ActionResult<Guid>> UpdateGathering(Guid id, [FromBody] GatheringsRequest request)
    {
        var gatheringId = await _gatheringService.UpdateGathering(
            id,
            request.Title,
            request.Description,
            request.TargetAmount,
            request.CurrentAmount,
            request.MembersCount,
            request.IsVerified
        );
        
        return Ok(gatheringId);
    }

    [HttpDelete("{id:guid}")]
    [Authorize]
    public async Task<ActionResult<Guid>> DeleteGathering(Guid id)
    {
        return Ok(await _gatheringService.DeleteGathering(id));
    }
}