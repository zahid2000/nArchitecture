

namespace Application.Features.Brands.Rules;

public class BrandBusinnesRules
{
    private readonly IBrandRepository _brandRepository;

    public BrandBusinnesRules(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task BrandNameCanNotBeDuplicatedWhenInserted(string name)
    {
        IPaginate<Brand> result = await _brandRepository.GetListAsync(b => b.Name == name);
        if (result.Items.Any()) throw new BusinessException("Brand name exists.");
    }
}
