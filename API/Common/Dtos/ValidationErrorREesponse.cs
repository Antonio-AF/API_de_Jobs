namespace TWJobs.API.Common.Dtos;

public class ValidationErrorResponse : ErrorResponse
{
    public IDictionary<string, string[]>? Errors { get; set; }
    
}