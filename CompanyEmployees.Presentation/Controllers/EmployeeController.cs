using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Contracts;
using Service.Contracts.DTO;

namespace CompanyEmployees.Presentation.Controllers;

[Route("api/companies/{companyId:guid}/employees")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    private readonly ILogger<EmployeeController> _logger;

    public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger)
    {
        _employeeService = employeeService;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetCompanies(Guid companyId)
    {
        var employees = _employeeService.GetAllEmployeesOfCompany(companyId, false);
        return Ok(employees);
    }
    [HttpGet("{id:guid}")]
    public IActionResult GetCompany(Guid companyId, Guid id)
    {
        var employee = _employeeService.GetEmployee(companyId, id, false);
        return Ok(employee);
    }
}