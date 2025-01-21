using Campaign.Contract.Responses.Customers;
using MediatR;

namespace Campaign.Application.Features.Campaigns.Query.SurpriseWheelCustomers;

public class SurpriseWheelCustomersQuery : IRequest<CampaignEligibilityResponse>;