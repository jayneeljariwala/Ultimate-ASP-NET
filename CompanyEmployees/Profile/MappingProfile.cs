using AutoMapper;
using Shared.DataTransferObjects;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Company, CompanyDTO>()
            .ForMember(c => c.FullAddress,
                opt => opt.MapFrom(
                    src => string.Join(' ', new[] { src.Address, src.Country })
            )
        );

        CreateMap<Employee, EmployeeDTO>();
    }
}