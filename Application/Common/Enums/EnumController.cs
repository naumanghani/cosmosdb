using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreIMS.Application.EnumQueries;
using Microsoft.AspNetCore.Authorization;

namespace CoreIMS.API.Controllers.ItemDefinition
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]

    public class EnumController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        public EnumController(ILogger<EnumController> logger, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }
      

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return Ok(await _mediator.Send(new LookupEnumsQuery()));

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnum(int id)
        {
            return Ok();
            //return Ok(await _mediator.Send(new GetEnumQueryByIdQuery() { Id = id }));
        }

    }
}
