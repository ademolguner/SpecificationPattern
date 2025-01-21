using Campaign.Application.Common.Constants;
using Campaign.Application.Services.Interfaces.Common;
using Campaign.Domain;
using Campaign.Infrastructure.Specifications.Composites;
using Campaign.Infrastructure.Specifications.DomainModelSpecifications.Customers;
using Campaign.Infrastructure.Specifications.Interfaces;

namespace Campaign.Application.Specifications.Composites.Campaigns.SemesterHolidays;

/// <summary>
/// Blacklist’te olan müşteriler KAMPANYALARA UYGUN DEĞİL.
/// </summary>
public class BlacklistCampaignCheck : ICampaignCheck<Customer>
{
    public string? CheckEligibility(Customer customer)
    {
        var blacklistSpecification = new NotSpecification<Customer>(
            new CitySpecification(ApplicationConstant.BlackCities.ToArray())
        );

        return blacklistSpecification.IsSatisfiedBy(customer) 
            ? "- Blacklist’te olduğu için kampanyaya uygun değil." 
            : null;
    }
}