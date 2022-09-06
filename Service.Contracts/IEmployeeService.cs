using Service.Contracts.DTO;

namespace Service.Contracts;

public interface IEmployeeService
{
    IEnumerable<EmployeeDto> GetAllEmployeesOfCompany(Guid companyId, bool trackingChanges);
    EmployeeDto GetEmployee(Guid companyId, Guid id, bool trackingChanges);
}