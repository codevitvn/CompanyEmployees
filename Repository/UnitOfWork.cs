using Contracts;

namespace Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly CompanyEmployeeContext _context;

    public UnitOfWork(CompanyEmployeeContext context)
    {
        _context = context;
    }

    public void Save() => _context.SaveChanges();
}