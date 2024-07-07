using TWJobs.API.Common.Dtos;

namespace TWJobs.API.Common.Assemblers;

public interface IAssembler<T> where T : ResourseResponse
{
    T ToResource(T resource, HttpContext context);
    ICollection<T> ToResourceCollection(ICollection<T> resources, HttpContext context)
    {
        return resources.Select(r => ToResource(r, context)).ToList();
    }

}