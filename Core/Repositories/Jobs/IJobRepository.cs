using TWJobs.Core.Models;


namespace TWJobs.Core.Repositories.Jobs;


public interface IJobRepository : ICrudRepository<Job, int>, IPageRepository<Job>
{
    void DeleteById(int id);
    new bool ExistsById(int id);
}
