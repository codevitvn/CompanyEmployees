using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Model;
using Microsoft.Extensions.Logging;
using Service.Contracts;
using Service.Contracts.DTO;

namespace Service;

public sealed class CompanyService : ICompanyService
{
    private readonly ILogger<CompanyService> _logger;
    private readonly ICompanyRepository _repository;
    private readonly IMapper _mapper;

    public CompanyService(ILogger<CompanyService> logger, ICompanyRepository repository, IMapper mapper)
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    }

    public IEnumerable<CompanyDto> GetAllCompanies(bool trackingChanges)
    {
        try
        {
            var companies = _repository.FindAll(trackingChanges)
                .OrderBy(x => x.Name)
                .ToList();

            return _mapper.Map<IEnumerable<CompanyDto>>(companies);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Something went wrong");
            throw;
        }
    }

    public CompanyDto GetCompany(Guid id, bool trackingChanges)
    {
        var company = _repository.FindByCondition(c => c.Id.Equals(id), trackingChanges)
            .SingleOrDefault();

        if (company == null)
        {
            throw new CompanyNotFoundException(id);
        }
        return _mapper.Map<CompanyDto>(company);
    }
}