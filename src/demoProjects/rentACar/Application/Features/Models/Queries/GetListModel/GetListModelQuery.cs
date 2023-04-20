﻿using Application.Features.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries.GetListModel;

public class GetListModelQuery:IRequest<ModelListModel>
{
    public PageRequest PageRequest { get; set; }
    public class GetListModelQueryHandler : IRequestHandler<GetListModelQuery, ModelListModel>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public GetListModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<ModelListModel> Handle(GetListModelQuery request, CancellationToken cancellationToken)
        {                   //car model
         IPaginate<Model> models=await   _modelRepository.GetListAsync(include:
                                          m=>m.Include(c=>c.Brand),
                                          index:request.PageRequest.Page,
                                          size:request.PageRequest.PageSize
                                               );
            //data model             
            ModelListModel mappedModels=_mapper.Map<ModelListModel>(models);
            return mappedModels;
        }
    }
}
