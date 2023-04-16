using Application.Features.Brands.Rules;

namespace Application.Features.Brands.Queries.GetByIdBrand;

public record GetByIdBrandQuery(int id):IRequest<BrandGetByIdDto>;
public class GetByIdBrandQueryHandler : IRequestHandler<GetByIdBrandQuery, BrandGetByIdDto>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;
    private readonly BrandBusinnesRules _brandBusinnesRules;

    public GetByIdBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinnesRules brandBusinnesRules)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
        _brandBusinnesRules = brandBusinnesRules;
    }

    public async Task<BrandGetByIdDto> Handle(GetByIdBrandQuery request, CancellationToken cancellationToken)
    {
     Brand? brand= await  _brandRepository.GetAsync(b => b.Id == request.id);

        _brandBusinnesRules.BrandShouldExistsWhenRequested(brand);

        BrandGetByIdDto brandGetByIdDto= _mapper.Map<BrandGetByIdDto>(brand);
        return brandGetByIdDto;
    }
}
