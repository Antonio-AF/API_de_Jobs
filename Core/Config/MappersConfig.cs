using TWJobs.API.Jobs.Mappers;

namespace TWJobs.Core.Config;

public static class MappersConfig
{
    public static void RegisterMappers(this IServiceCollection services)
    {
        services.AddScoped<IJobMapper, JobMapper>();
    }
}