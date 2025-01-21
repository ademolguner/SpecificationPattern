using System.Linq.Expressions;
using Campaign.Domain;
using Campaign.Domain.Common.Enums;
using Campaign.Infrastructure.Specifications.Composites;
using Campaign.Infrastructure.Specifications.DomainModelSpecifications.Customers;

namespace Campaign.Application.Common.Utilities;


/// <summary>
/// 
/// </summary>
public static class CampaignSpecificationUtility 
{
    public static Expression<Func<Customer, bool>> MinTotalPurchaseAndGoldAndAgeRangeCampaignCheck()
    {
        var purchaseSpecification = new MinimumPurchaseAmountSpecification(500);
        var membershipSpecification = new MembershipLevelSpecification(MembershipLevel.Gold);
        var ageSpecification = new AgeRangeSpecification(40, 60);
        
        var combinedSpecification = new AndSpecification<Customer>(purchaseSpecification, membershipSpecification);
        combinedSpecification = new AndSpecification<Customer>(combinedSpecification, ageSpecification);

        return combinedSpecification.ConvertToExpression();
    }
}