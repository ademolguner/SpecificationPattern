using Campaign.Application.Services.Interfaces;
using Campaign.Application.Services.Interfaces.Common;
using Campaign.Contract.Responses.Campaigns;
using Campaign.Domain;
using Campaign.Infrastructure.Specifications.Interfaces;

namespace Campaign.Application.Services;

public class CampaignEligibilityService(IEnumerable<ICampaignCheck<Customer>> campaignChecks):ICampaignEligibilityService
{
    public EligibilityCheckByCustomerResult SemesterHolidayCampaignCheck(Customer customer)
    {
        var eligibleCampaigns = campaignChecks
                                            .Select(check => check.CheckEligibility(customer))
                                            .Where(result => result != null)
                                            .ToList();

        return new EligibilityCheckByCustomerResult
        {
            CustomerId = customer.GetId(),
            Message = $"Kıymetli Hepsiburada kullanıcımız {customer.Name}, size uygun kampanyalarımız var, Kuponlar bitmeden gel!!!",
            EligibleCampaigns = eligibleCampaigns
        };
    }
}










