using Application.Features.Models.Models;

namespace Application.Features.Models.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Model, ModelListDto>()
            .ForMember(c=>c.BrandName,opt=>opt.MapFrom(c=>c.Brand.Name))
            .ReverseMap();
        CreateMap<IPaginate<Model>,ModelListModel>().ReverseMap();
    }
}
