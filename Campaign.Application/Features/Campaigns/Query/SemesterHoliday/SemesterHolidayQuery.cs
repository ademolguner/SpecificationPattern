using Campaign.Contract.Responses.Campaigns;
using MediatR;

namespace Campaign.Application.Features.Campaigns.Query.SemesterHoliday;

public class SemesterHolidayQuery(Guid customerId) : IRequest<EligibilityCheckByCustomerResult>
{
    public Guid CustomerId { get; init; } = customerId;
}