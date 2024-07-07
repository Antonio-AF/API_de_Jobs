using FluentValidation;
using TWJobs.API.Jobs.Dtos;
using TWJobs.API.Jobs.Validators;

namespace TWJobs.Core.Config;

public static class ValidatorsConfig
{
    public static void RegisterValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<JobRequest>, JobRequestValidator>();
    }
}