using Campaign.Domain.Common.Enums;

namespace Campaign.Contract.Requests.Campaigns;

public class CreateCustomerRequest
{
    public required string Name { get; set; }
    public decimal TotalPurchaseAmount { get; set; }
    public MembershipLevel MembershipLevel { get; set; }
    public DateTime RegistrationDate { get; set; }
    public required string City { get; set; }
    public int Age { get; set; }
}