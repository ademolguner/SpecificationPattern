using Campaign.Application.Features.Campaigns.Query.SemesterHoliday;
using Campaign.Application.Features.Campaigns.Query.SurpriseWheelCustomers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Campaign.Api.Controllers;


[ApiController]
[Route("api/campaign")]
public class CampaignController(IMediator mediator) : ControllerBase
{
    
    [HttpGet("customers/{customerId:Guid}/campaigns/semester-holiday")]
    public async Task<IActionResult> GetSemesterHolidayEligibilityCampaigns([FromRoute] Guid customerId)
    {
        var result = await mediator.Send(new SemesterHolidayQuery(customerId));
        return Ok(result);
    }
    
    [HttpGet("campaigns/surprise-wheel/customers")]
    public async Task<IActionResult> GetSurpriseWheelCustomers()
    {
        var result = await mediator.Send(new SurpriseWheelCustomersQuery());
        return Ok(result);
    }
}