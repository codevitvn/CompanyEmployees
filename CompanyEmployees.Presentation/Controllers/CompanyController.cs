using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Contracts;
using Service.Contracts.DTO;

namespace CompanyEmployees.Presentation.Controllers;

[Route("api/companies")]
[ApiController]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyService;
    private readonly ILogger<CompanyController> _logger;

    public CompanyController(ICompanyService companyService, ILogger<CompanyController> logger)
    {
        _companyService = companyService;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetCompanies()
    {
        var companies = _companyService.GetAllCompanies(false);
        return Ok(companies);
    }
    [HttpGet("{id:guid}")]
    public IActionResult GetCompany(Guid id)
    {
        var company = _companyService.GetCompany(id, false);
        return Ok(company);
    }
}