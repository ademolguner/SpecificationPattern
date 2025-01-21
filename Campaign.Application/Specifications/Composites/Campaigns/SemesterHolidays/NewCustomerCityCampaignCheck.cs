using Campaign.Application.Services.Interfaces.Common;
using Campaign.Domain;
using Campaign.Infrastructure.Specifications.Composites;
using Campaign.Infrastructure.Specifications.DomainModelSpecifications.Customers;
using Campaign.Infrastructure.Specifications.Interfaces;

namespace Campaign.Application.Specifications.Composites.Campaigns.SemesterHolidays;

/// <summary>
///  Kampanya 2: Yeni Müşteri ve Büyük Şehir İndirimi
///      *  Kayıt süresi 1 yıldan az olan, VE
///      *  Şehir: İstanbul, Ankara veya İzmir olan, VE
///      *  Alışveriş tutarı en az 500 TL olan müşteriler.
/// </summary>
/// <returns></returns>
public class NewCustomerCityCampaignCheck : ICampaignCheck<Customer>
{
    public string? CheckEligibility(Customer customer)
    {
        var newCustomerCityCampaignSpecification = new AndSpecification<Customer>(
            new RegistrationDurationSpecification(0),
            new AndSpecification<Customer>(
                new CitySpecification("İstanbul", "Ankara", "İzmir"),
                new MinimumPurchaseAmountSpecification(500)
            )
        );

        var checkResponse = newCustomerCityCampaignSpecification.IsSatisfiedBy(customer);

        return checkResponse
            ? "- Yeni Müşteri ve Büyük Şehir İndirimi Kampanyasına uygun!"
            : null;
    }
}