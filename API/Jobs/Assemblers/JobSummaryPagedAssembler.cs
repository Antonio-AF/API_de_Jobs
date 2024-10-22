using TWJobs.API.Common.Assemblers;
using TWJobs.API.Common.Dtos;

namespace TWJobs.API.Jobs.Dtos;


public class JobSummaryPagedAssembler : IPagedAssembler<JobSummaryResponse>
{
    private readonly LinkGenerator _linkGenerator;
    private readonly IAssembler<JobSummaryResponse> _jobSummaryAssembler;

    public JobSummaryPagedAssembler(LinkGenerator linkGenerator, IAssembler<JobSummaryResponse> jobSummaryAssembler)
    {
        _linkGenerator = linkGenerator;
        _jobSummaryAssembler = jobSummaryAssembler;
    }

    public PagedResponse<JobSummaryResponse> ToPagesdResource(PagedResponse<JobSummaryResponse> pagedResource, HttpContext context)
    {
        pagedResource.Items = _jobSummaryAssembler.ToResourceCollection(pagedResource.Items, context);

        var firstPageLink = new LinkResponse(
            _linkGenerator.GetUriByName(context, "FindAllJobs", new { page = pagedResource.FirstPage, size = pagedResource.PageSize }),
            "GET",
            "firstPage"
        );

        var lastPageLink = new LinkResponse(
            _linkGenerator.GetUriByName(context, "FindAllJobs", new { page = pagedResource.LastPage, size = pagedResource.PageSize }),
            "GET",
            "lastPage"
        );
        var nextPageLink = new LinkResponse(
            _linkGenerator.GetUriByName(context, "FindAllJobs", new { page = pagedResource.PageNumber + 1, size = pagedResource.PageSize }),
            "GET",
            "nextPage"
        );

        var previousPageLink = new LinkResponse(
            _linkGenerator.GetUriByName(context, "FindAllJobs", new { page = pagedResource.PageNumber - 1, size = pagedResource.PageSize }),
            "GET",
            "previousPage"
        );

        pagedResource.AddLinks(firstPageLink, lastPageLink);
        pagedResource.AddLinkIf(pagedResource.HasNextPage, nextPageLink);
        pagedResource.AddLinkIf(pagedResource.HasPreviousPage, previousPageLink);
        return pagedResource;

    }
}