namespace Campaign.Contract.Requests.Campaigns;

public class UpdateCustomerRequest:CreateCustomerRequest
{
    public Guid Id { get; set; }
}