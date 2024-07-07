using System.Reflection;
using TWJobs.API.Common.Dtos;

namespace TWJobs.API.Jobs.Dtos;

public class JobDetailResponse : ResourseResponse
{
    public int Id { get; set; }
    public string Title   { get; set; } = string.Empty;
    public decimal Salary { get; set; } 
    public ICollection<string> Requirements { get; set; } = new List<string>();
    
}