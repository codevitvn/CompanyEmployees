using Entities.Model;
using Service.Contracts.DTO;

namespace Service.Contracts;

public interface ICompanyService
{
    IEnumerable<CompanyDto> GetAllCompanies(bool trackingChanges);
    CompanyDto GetCompany(Guid id, bool trackingChanges);
}