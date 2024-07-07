using System.Threading.Tasks.Dataflow;
using TWJobs.API.Common.Dtos;
using TWJobs.API.Jobs.Dtos;
using TWJobs.Core.Models;
using TWJobs.Core.Repositories;

namespace TWJobs.API.Jobs.Mappers;

public interface IJobMapper
{
    JobSummaryResponse ToSummaryResponse(Job job);
    JobDetailResponse ToDetailResponse(Job job);
    PagedResponse<JobSummaryResponse> ToPagedSummaryResponse(PagedResult<Job> pagedResult);
    Job ToModel(JobRequest jobRequest);
}