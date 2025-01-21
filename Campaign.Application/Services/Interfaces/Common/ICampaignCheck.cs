namespace Campaign.Application.Services.Interfaces.Common;

public  interface ICampaignCheck<in T>
{
    string? CheckEligibility(T model);
}
