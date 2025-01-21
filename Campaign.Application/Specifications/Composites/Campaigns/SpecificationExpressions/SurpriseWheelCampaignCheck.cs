using System.Linq.Expressions;
using Campaign.Application.Services.Interfaces.Common;
using Campaign.Domain;
using Campaign.Domain.Common.Enums;
using Campaign.Infrastructure.Specifications.Composites;
using Campaign.Infrastructure.Specifications.DomainModelSpecifications.Customers;
using Campaign.Infrastructure.Specifications.Interfaces;

namespace Campaign.Application.Specifications.Composites.Campaigns.SpecificationExpressions;

public class SurpriseWheelCampaignCheck:ISpecificationExpressionCheck<Customer>
{
    /// <summary>
    ///     Altın Çark Kampanya kosulları
    ///        En az 500 TL alışveriş yapmış (TotalPurchaseAmountSpecification),
    ///        Gold seviyesinde üyeliğe sahip (MembershipLevelSpecification),
    ///        25-45 yaş aralığında (AgeRangeSpecification).
    /// </summary>
    public Expression<Func<Customer, bool>> ConvertToExpression()
    {
        var purchaseSpecification = new MinimumPurchaseAmountSpecification(500);
        var membershipSpecification = new MembershipLevelSpecification(MembershipLevel.Gold);
        var ageSpecification = new AgeRangeSpecification(24, 45);
        
        var combinedSpecification = new AndSpecification<Customer>(purchaseSpecification, membershipSpecification);
        combinedSpecification = new AndSpecification<Customer>(combinedSpecification, ageSpecification);

        return combinedSpecification.ConvertToExpression();
    }
}