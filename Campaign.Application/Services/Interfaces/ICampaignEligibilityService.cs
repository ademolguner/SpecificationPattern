using Campaign.Contract.Responses.Campaigns;
using Campaign.Domain;

namespace Campaign.Application.Services.Interfaces;

public interface ICampaignEligibilityService
{
    EligibilityCheckByCustomerResult SemesterHolidayCampaignCheck(Customer customer);
}
