using TWJobs.API.Common.Assemblers;
using TWJobs.API.Common.Dtos;
using TWJobs.API.Jobs.Dtos;


namespace TWJobs.API.Jobs.Assemble;

public class JobDetailAssembler : IAssembler<JobDetailResponse>
{
    
    private readonly LinkGenerator _linkGenerator;

    public JobDetailAssembler(LinkGenerator linkGenerator)
    {
        _linkGenerator = linkGenerator;
    }

    public JobDetailResponse ToResource(JobDetailResponse resource, HttpContext context)
    {
        var selfLink = new LinkResponse(
           _linkGenerator.GetUriByName(context, "FindJobById", new { Id = resource.Id }), "GET", "self"
        );
        var updateLink = new LinkResponse(
            _linkGenerator.GetUriByName(context, "UpdateJobById", new { Id = resource.Id }), "PUT", "update"
        );

        var deleteLink = new LinkResponse(
            _linkGenerator.GetUriByName(context, "DeleteJobById", new { Id = resource.Id }), "DELETE", "delete"
        );
        resource.AddLinks(selfLink, updateLink, deleteLink);
        return resource;
    }
}