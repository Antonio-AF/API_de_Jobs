namespace TWJobs.API.Jobs.Dtos;

public class JobRequest
{
    public string Title { get; set; } = string.Empty;
    public decimal Salary { get; set; }
    public ICollection<string> Requirements { get; set; } = [];
}
