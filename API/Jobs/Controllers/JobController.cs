using Microsoft.AspNetCore.Mvc;
using TWJobs.API.Common.Assemblers;
using TWJobs.API.Common.Dtos;
using TWJobs.API.Jobs.Dtos;
using TWJobs.API.Jobs.Services;
using TWJobs.Core.Exceptions;


namespace TWJobs.API.Jobs.Controllers;

[ApiController]
[Route("/api/jobs")]
public class JobController : ControllerBase
{
    private readonly IJobService _jobService;
    private readonly IAssembler<JobDetailResponse> _jobDetailAssembler;
    private readonly IPagedAssembler<JobSummaryResponse> _jobSummaryPagedAssembler;

    public JobController(IJobService jobService, IAssembler<JobDetailResponse> jobDetailAssembler, IPagedAssembler<JobSummaryResponse> jobSummaryPagedAssembler)
    {
        _jobService = jobService;
        _jobDetailAssembler = jobDetailAssembler;
        _jobSummaryPagedAssembler = jobSummaryPagedAssembler;
    }

    [HttpGet(Name = "FindAllJobs")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResponse<JobSummaryResponse>))]
    public IActionResult FindAll([FromQuery] int page, [FromQuery] int size)
    {
        var body = _jobService.FindAll(page, size);     
        return Ok(_jobSummaryPagedAssembler.ToPagesdResource(body, HttpContext));
    }

    [HttpGet("{id}", Name = "FindJobById")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(JobDetailResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationErrorResponse))]
    public IActionResult FindById([FromRoute] int id)
    {
        try
        {
            var body = _jobService.FindById(id);
            return Ok(_jobDetailAssembler.ToResource(body, HttpContext));
        }
        catch (ModelNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost(Name = "CreateJob")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JobDetailResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
    public IActionResult Create([FromBody] JobRequest jobRequest)
    {
        var body = _jobService.Create(jobRequest);
        return CreatedAtAction(
            nameof(FindById),
            new { Id = body.Id },
            _jobDetailAssembler.ToResource(body, HttpContext)
        );
        
    }

    [HttpPut("{id}", Name = "UpdateJobById")]
    [ProducesResponseType(StatusCodes.Status200OK, Type=typeof(JobDetailResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type=typeof(ValidationErrorResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type=typeof(ErrorResponse))]    
    public IActionResult UpdateById([FromRoute] int id, [FromBody] JobRequest jobRequest)
    {
        var body = _jobService.UpdateById(id, jobRequest);
        return Ok(_jobDetailAssembler.ToResource(body, HttpContext)
        );
    }

    [HttpDelete("{id}", Name = "DeleteJobById")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
    public IActionResult DeleteById([FromRoute] int id)
    {
        _jobService.DeleteById(id);
        return NoContent();
    }
}