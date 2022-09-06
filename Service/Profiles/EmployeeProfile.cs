using AutoMapper;
using Entities.Model;
using Service.Contracts.DTO;

namespace Service.Profiles;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, EmployeeDto>();
    }
}