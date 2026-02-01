using AutoMapper;
using Shared.DataTransferObjects;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Company, CompanyDTO>()
            .ForCtorParam("FullAddress",
                opt => opt.MapFrom(
                    src => string.Join(' ', new[] { src.Address, src.Country })
            )
        );
    }
}