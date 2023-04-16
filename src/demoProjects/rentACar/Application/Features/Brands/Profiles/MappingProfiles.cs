namespace Application.Features.Brands.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Brand, CreatedBrandDto>().ReverseMap();
            CreateMap<Brand, CreateBrandCommand>().ReverseMap();
            CreateMap<IPaginate<Brand>,BrandListModel>().ReverseMap();
            CreateMap<Brand, BrandListDto>().ReverseMap();
            CreateMap<Brand, BrandGetByIdDto>().ReverseMap();
        }
    }
}
