using System.Reflection;
using Campaign.Application.Repositories;
using Campaign.Application.Services;
using Campaign.Application.Services.Interfaces;
using Campaign.Application.Services.Interfaces.Common;
using Campaign.Application.Specifications.Composites.Campaigns.SemesterHolidays;
using Campaign.Application.Specifications.Composites.Campaigns.SpecificationExpressions;
using Campaign.Domain;
using Campaign.Infrastructure.Context.Repositories;
using Campaign.Infrastructure.Specifications.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Campaign.Application;

public static class DependencyResolver
{
    
    public static  IServiceCollection AddServiceDependency(this IServiceCollection services,IConfiguration configuration)
    {
        RegisterCampaignCheckEligibilityModel(services);
        RegisterCampaignCheckExpressionModel(services);
        
        return services
            .AddScoped<ICampaignEligibilityService, CampaignEligibilityService>();
    }


    private static void RegisterCampaignCheckEligibilityModel(IServiceCollection services)
    {
        services
            .AddScoped<ICampaignCheck<Customer>, BlacklistCampaignCheck>()
            .AddScoped<ICampaignCheck<Customer>, LoyalCustomerCampaignCheck>()
            .AddScoped<ICampaignCheck<Customer>, NewCustomerCityCampaignCheck>()
            .AddScoped<ICampaignCheck<Customer>, SpecialMembershipOffersCampaignCheck>();
    }

    private static void RegisterCampaignCheckExpressionModel(IServiceCollection services)
    {
         services
            .AddScoped<ISpecificationExpressionCheck<Customer>, SurpriseWheelCampaignCheck>();

    }
    
    public static  IServiceCollection AddRepositoryDependency(this IServiceCollection services)
    {
        return services
            .AddScoped<ICustomerRepository, CustomerRepository>();
    }
    public static void AddMediatRDependency(this IServiceCollection services)
    {
        services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    }
}