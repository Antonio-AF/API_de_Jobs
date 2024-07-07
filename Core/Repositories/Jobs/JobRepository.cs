using Microsoft.EntityFrameworkCore;
using TWJobs.Core.Data.Contexts;
using TWJobs.Core.Models;
using TWJobs.Core.Repositories;

namespace TWJobs.Core.Repositories.Jobs;

public class JobRepository : IJobRepository
{
    private readonly TWJobsDbContext _context;

    public JobRepository(TWJobsDbContext context)
    {
        _context = context;
    }

    public Job Create(Job model)
    {
        _context.Jobs.Add(model);
        _context.SaveChanges();
        return model;
    }

    public void DeleteById(int id)
    {
        var job = _context.Jobs.Find(id);
        if (job is not null)
        {
            _context.Jobs.Remove(job);
            _context.SaveChanges();
        }        
    }

    public void DeleteById(Job model)
    {
        throw new NotImplementedException();
    }
    
    public bool ExistsById(int id)
    {
        return _context.Jobs.Any(j => j.Id == id);
    }

    public ICollection<Job> FindAll()
    {
        return _context.Jobs.AsNoTracking().ToList();
    }

    public PagedResult<Job> FindAll(PaginationOption options)
    {
        var totalElements = _context.Jobs.Count();
        var items = _context.Jobs.Skip((options.PageNumeber - 1) * options.PageSize).Take(options.PageSize).ToList();
        return new PagedResult<Job>(items, options.PageNumeber, options.PageSize, totalElements);
    }

    public Job? FindById(int id)
    {
        return _context.Jobs.AsNoTracking().FirstOrDefault(j => j.Id == id);
    }

    public Job Update(Job model)
    {
        _context.Jobs.Update(model);
        _context.SaveChanges();
        return model;
    }

}