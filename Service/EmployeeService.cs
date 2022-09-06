using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Microsoft.Extensions.Logging;
using Service.Contracts;
using Service.Contracts.DTO;

namespace Service;

public sealed class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repository;
    private readonly ICompanyRepository _companyRepository;
    private readonly ILogger<EmployeeService> _logger;
    private readonly IMapper _mapper;

    public EmployeeService(ILogger<EmployeeService> logger, IEmployeeRepository repository, ICompanyRepository companyRepository, IMapper mapper)
    {
        _logger = logger;
        _repository = repository;
        _companyRepository = companyRepository;
        _mapper = mapper;
    }

    public IEnumerable<EmployeeDto> GetAllEmployeesOfCompany(Guid companyId, bool trackingChanges)
    {
        var company = _companyRepository.FindByCondition(c => c.Id.Equals(companyId), trackingChanges)
            .SingleOrDefault();

        if (company == null)
        {
            throw new CompanyNotFoundException(companyId);
        }

        var employees = _repository.FindByCondition(e => e.CompanyId.Equals(companyId), trackingChanges: false)
            .OrderBy(e => e.Name)
            .ToList();

        return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
    }

    public EmployeeDto GetEmployee(Guid companyId, Guid id, bool trackingChanges)
    {
        var company = _companyRepository.FindByCondition(c => c.Id.Equals(companyId), trackingChanges)
            .SingleOrDefault();

        if (company == null)
        {
            throw new CompanyNotFoundException(companyId);
        }

        var employee = _repository
            .FindByCondition(e => e.CompanyId.Equals(companyId) && e.Id.Equals(id), trackingChanges: false)
            .SingleOrDefault();
        if (employee == null)
        {
            throw new EmployeeNotFoundException(id);
        }

        return _mapper.Map<EmployeeDto>(employee);
    }
}