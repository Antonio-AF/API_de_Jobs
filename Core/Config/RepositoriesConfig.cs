using TWJobs.Core.Repositories.Jobs;

namespace TWJobs.Core.Config;

public static class RepositoriesConfig
{
    public static void RegiterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IJobRepository, JobRepository>();
    }
}