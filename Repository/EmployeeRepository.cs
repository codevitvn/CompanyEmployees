using Contracts;
using Entities.Model;
using Microsoft.Extensions.Logging;

namespace Repository;

public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
{
    private readonly ILogger<EmployeeRepository> _logger;
    public EmployeeRepository(CompanyEmployeeContext companyEmployeeContext, ILogger<EmployeeRepository> logger) : base(companyEmployeeContext)
    {
        _logger = logger;
    }
}