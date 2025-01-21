using Campaign.Application.Services.Interfaces;
using Campaign.Contract.Responses.Campaigns;
using Campaign.Infrastructure.Context.Repositories;
using MediatR;

namespace Campaign.Application.Features.Campaigns.Query.SemesterHoliday;


public class SemesterHolidayQueryHandler(
    ICampaignEligibilityService campaignEligibilityService,
    ICustomerRepository customerRepository)
    : IRequestHandler<SemesterHolidayQuery, EligibilityCheckByCustomerResult>
{
    public async Task<EligibilityCheckByCustomerResult> Handle(SemesterHolidayQuery request,
                                                               CancellationToken cancellationToken)
    {
        var customer = await customerRepository.GetByIdAsync(request.CustomerId, cancellationToken);
        if (customer == null)
            throw new ArgumentNullException($"Customer not found for Id: {request.CustomerId}", nameof(request.CustomerId));

        var customerCampaignCheck = campaignEligibilityService.SemesterHolidayCampaignCheck(customer);
        return await Task.FromResult(customerCampaignCheck);
    }
}

