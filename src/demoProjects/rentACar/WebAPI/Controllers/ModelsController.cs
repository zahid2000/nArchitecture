﻿using Application.Features.Models.Models;
using Application.Features.Models.Queries.GetListModel;
using Application.Features.Models.Queries.GetListModelByDynamic;
using Core.Persistence.Dynamic;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ModelsController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery]PageRequest pageRequest )
    {
        GetListModelQuery query = new GetListModelQuery { PageRequest=pageRequest};
        ModelListModel result = await Mediator.Send(query);
        return Ok(result);
    }
    [HttpPost("GetList/ByDynamic")]
    public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest,[FromBody]Dynamic dynamic)
    {
        GetListModelByDynamicQuery query = new GetListModelByDynamicQuery { PageRequest = pageRequest ,Dynamic=dynamic};
        ModelListModel result = await Mediator.Send(query);
        return Ok(result);
    }
}
