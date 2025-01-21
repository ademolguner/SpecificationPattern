namespace Campaign.Contract.Responses.Campaigns;

public class EligibilityCheckByCustomerResult
{
    public Guid CustomerId { get; set; }
    public List<string> EligibleCampaigns { get; set; } = [];
    
    public required string Message { get; set; }
}