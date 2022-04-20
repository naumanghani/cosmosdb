using Application.SampleCmdQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SampleController : ControllerBase
    {
       

        private readonly ILogger<SampleController> _logger;
        private readonly IMediator _mediator;

        public SampleController(ILogger<SampleController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {

            return Ok(await _mediator.Send(new GetDataQuery() ));
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Post(string id)
        {
            return Ok(await _mediator.Send(new GetDataCmd() {Id = id }));
        }

        [HttpPost("Item")]
        public async Task<IActionResult> PostItem(SaveDataCmd req)
        {
            return Ok(await _mediator.Send(req));
        }
    }
}
