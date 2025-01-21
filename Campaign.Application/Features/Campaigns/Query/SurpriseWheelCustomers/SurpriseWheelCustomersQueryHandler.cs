using Campaign.Application.Services.Interfaces.Common;
using Campaign.Application.Specifications.Composites.Campaigns.SpecificationExpressions;
using Campaign.Contract.Responses.Customers;
using Campaign.Domain;
using Campaign.Infrastructure.Context.Repositories;
using Campaign.Infrastructure.Specifications.Interfaces;
using MediatR;

namespace Campaign.Application.Features.Campaigns.Query.SurpriseWheelCustomers;

public class SurpriseWheelCustomersQueryHandler(
    ICustomerRepository customerRepository,
    ISpecificationExpressionCheck<Customer> specificationExpressionCheck)
    : IRequestHandler<SurpriseWheelCustomersQuery, CampaignEligibilityResponse>
{
    public async Task<CampaignEligibilityResponse> Handle(SurpriseWheelCustomersQuery request, CancellationToken cancellationToken)
    {
        var response = new CampaignEligibilityResponse { Campaign = "Sürpriz Çarkı!" };
        var expressionQuery = specificationExpressionCheck.ConvertToExpression();

        var customers = await customerRepository
                               .GetAllAsync(expressionQuery.Compile(), cancellationToken);

        foreach (var customer in customers)
        {
            response.EligibleCustomers.Add(new EligibleCustomer()
            {
                CustomerId = customer.Id,
                Name = customer.Name
            });
        }

        return response;
    }
}