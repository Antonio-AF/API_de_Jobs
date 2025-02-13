using TWJobs.API.Common.Assemblers;
using TWJobs.API.Jobs.Assemble;
using TWJobs.API.Jobs.Assembler;
using TWJobs.API.Jobs.Dtos;

namespace TWJobs.Core.Config;

public static class AssemblersConfig
{
    public static void RegisterAssemblers(this IServiceCollection services)
    {
        services.AddScoped<IAssembler<JobSummaryResponse>, JobSummaryAssembler>();
        services.AddScoped<IAssembler<JobDetailResponse>, JobDetailAssembler>();
        services.AddScoped<IPagedAssembler<JobSummaryResponse>, JobSummaryPagedAssembler>();
    }
}