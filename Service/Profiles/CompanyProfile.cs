using AutoMapper;
using Entities.Model;
using Service.Contracts.DTO;

namespace Service.Profiles;

public class CompanyProfile : Profile
{
    public CompanyProfile()
    {
        CreateMap<Company, CompanyDto>()
            .ForCtorParam("FullAddress",
                opt =>
                    opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));
    }
}