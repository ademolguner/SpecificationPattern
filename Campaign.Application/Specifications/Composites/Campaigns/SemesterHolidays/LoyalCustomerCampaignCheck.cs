using Campaign.Application.Services.Interfaces.Common;
using Campaign.Domain;
using Campaign.Infrastructure.Specifications.Composites;
using Campaign.Infrastructure.Specifications.DomainModelSpecifications.Customers;
using Campaign.Infrastructure.Specifications.Interfaces;

namespace Campaign.Application.Specifications.Composites.Campaigns.SemesterHolidays;

/// <summary>
///  Kampanya 1: Sadık Müşteri Kampanyası
///        * Kayıt süresi en az 3 yıl olan, VE
///        * Alışveriş tutarı en az 1000 TL olan müşteriler.
/// </summary>
public class LoyalCustomerCampaignCheck : ICampaignCheck<Customer>
{
    public string? CheckEligibility(Customer customer)
    {
        var loyalCustomerCampaignSpecification = new AndSpecification<Customer>(
            new RegistrationDurationSpecification(3),
            new MinimumPurchaseAmountSpecification(1000)
        );
        
        var checkResponse = loyalCustomerCampaignSpecification.IsSatisfiedBy(customer);
        
        return checkResponse
            ? "- Sadık Müşteri Kampanyasına uygun!" 
            : null;
    }
}