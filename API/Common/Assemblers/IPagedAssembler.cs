using TWJobs.API.Common.Dtos;

namespace TWJobs.API.Common.Assemblers;

public interface IPagedAssembler<R> where R : ResourseResponse
{
    PagedResponse<R> ToPagesdResource(PagedResponse<R> pagedResource, HttpContext context);
}