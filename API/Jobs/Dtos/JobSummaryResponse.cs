using TWJobs.API.Common.Dtos;

namespace TWJobs.API.Jobs.Dtos;

 public class JobSummaryResponse : ResourseResponse
 {
     public int Id { get; set; }
     public string Title { get; set; } = string.Empty;
 }