using Application.Features.Brands.Dtos;


namespace Application.Features.Brands.Models;

public class BrandListModel:BasePageableModel
{
    public IList<BrandListDto> Items { get; set; }
}
