using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Services.Respositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommand : IRequest<CreatedBrandDto>
    {
        public string? Name { get; set; }
        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandDto>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;
            private readonly BrandBusinnesRules _brandBusinnesRules;

            public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinnesRules brandBusinnesRules)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
                _brandBusinnesRules = brandBusinnesRules;
            }

            public async Task<CreatedBrandDto> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                await _brandBusinnesRules.BrandNameCanNotBeDuplicatedWhenInserted(request.Name);

                Brand mappedBrand = _mapper.Map<Brand>(request);
                Brand creatcreatedBrand = await _brandRepository.AddAsync(mappedBrand);
                CreatedBrandDto createdBrandDto = _mapper.Map<CreatedBrandDto>(creatcreatedBrand);
               
                return createdBrandDto;
            }
        }
    }
}
