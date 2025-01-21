using Campaign.Application.Services.Interfaces.Common;
using Campaign.Domain;
using Campaign.Domain.Common.Enums;
using Campaign.Infrastructure.Specifications.Composites;
using Campaign.Infrastructure.Specifications.DomainModelSpecifications.Customers;
using Campaign.Infrastructure.Specifications.Interfaces;

namespace Campaign.Application.Specifications.Composites.Campaigns.SemesterHolidays;

/// <summary>
/// Kampanya 3: Üyelik Düzeyi Özel Teklifi
///     *  Premium üyeler, VEYA
///     *  Gold üyelerden olup en az 2000 TL alışveriş yapan,  VE
///        Kayıt süresi en az 2 yıl olan müşteriler
/// </summary>
public class SpecialMembershipOffersCampaignCheck : ICampaignCheck<Customer>
{
    public string? CheckEligibility(Customer customer)
    {
        var premiumOrGoldCampaignSpecification = new OrSpecification<Customer>(
            new MembershipLevelSpecification(MembershipLevel.Premium),
            new AndSpecification<Customer>(
                new MembershipLevelSpecification(MembershipLevel.Gold),
                new MinimumPurchaseAmountSpecification(2000)
            )
        );

        var membershipOfferSpecification = new AndSpecification<Customer>(
            premiumOrGoldCampaignSpecification,
            new RegistrationDurationSpecification(2)
        );
        
        var checkResponse= membershipOfferSpecification.IsSatisfiedBy(customer);
        
        return checkResponse 
            ? "- Üyelik Düzeyi Özel Teklif Kampanyasına uygun!" 
            : null;
    }
}



