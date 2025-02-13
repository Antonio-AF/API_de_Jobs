using TWJobs.API.Common.Dtos;
using TWJobs.API.Jobs.Dtos;


namespace TWJobs.API.Jobs.Services;

public interface IJobService
{
    ICollection<JobSummaryResponse> FindAll();
    PagedResponse<JobSummaryResponse> FindAll(int page, int size);
    JobDetailResponse FindById(int id);
    JobDetailResponse Create(JobRequest jobRequest);
    JobDetailResponse UpdateById(int id, JobRequest jobRequest);
    void DeleteById(int id);
}