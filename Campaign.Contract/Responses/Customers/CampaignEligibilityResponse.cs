namespace Campaign.Contract.Responses.Customers;

public class CampaignEligibilityResponse
{
    public required string Campaign { get; set; }
    public List<EligibleCustomer> EligibleCustomers { get; set; } = [];
}

public class EligibleCustomer
{
    public Guid CustomerId { get; set; }
    public required string Name { get; set; }
}