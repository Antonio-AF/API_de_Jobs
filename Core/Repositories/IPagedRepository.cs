namespace TWJobs.Core.Repositories;

public interface IPageRepository<Model>
{
    PagedResult<Model> FindAll(PaginationOption options);
}