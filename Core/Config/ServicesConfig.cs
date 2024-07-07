using TWJobs.API.Jobs.Services;

namespace TWJobs.Core.Config;

public static class ServicesConfig
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IJobService, JobService>();
    }
}