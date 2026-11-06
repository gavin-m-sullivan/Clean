using Clean.Accounts.Api.Requests;
using Clean.Accounts.Api.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Accounts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRequest request)
        {
            return Created();
        }
        [HttpPost("{id}/updates")]
        public async Task<IActionResult> Update([FromBody] UpdateRequest request)
        {
            return Ok();
        }
        [HttpPost("{id}/close")]
        public async Task<IActionResult> Close([FromRoute] string id)
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            return Ok(new GetResponse());
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(new ListResponse());
        }
        [HttpGet("{id}/status")]
        public async Task<IActionResult> Status([FromRoute] string id)
        {
            return Ok(new StatusResponse());
        }
    }
}
