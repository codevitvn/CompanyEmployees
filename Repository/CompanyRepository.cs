using Contracts;
using Entities.Model;
using Microsoft.Extensions.Logging;

namespace Repository;

public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
{
    private readonly ILogger<CompanyRepository> _logger;
    public CompanyRepository(CompanyEmployeeContext companyEmployeeContext, ILogger<CompanyRepository> logger) : base(companyEmployeeContext)
    {
        _logger = logger;
    }
}