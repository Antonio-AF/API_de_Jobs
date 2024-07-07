namespace TWJobs.Core.Repositories;

public class PaginationOption
{

    public int PageNumeber { get; set; }
    public int PageSize { get; set; }


    public PaginationOption(int pageNumeber, int pageSize)
    {
        PageNumeber = pageNumeber < 1 ? 1 : pageNumeber;
        PageSize = pageSize < 1 ? 10 : pageSize;
    }


}