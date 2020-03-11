using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AccountApi.Models;
using AccountApi.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Reinforce.RestApi.Models;

namespace AccountApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
        }

        [HttpGet]
        public Task<IEnumerable<Account>> GetAsync(CancellationToken cancellationToken)
        {
            return _accountService.ReadAsync(cancellationToken);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Account>> GetAsync(string id, CancellationToken cancellationToken)
        {
            var account = await _accountService.ReadAsync(id, cancellationToken);
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }

        [HttpPatch]
        [ProducesResponseType(204)]
        public async Task<IActionResult> PatchAsync([FromBody] IEnumerable<Account> accounts, CancellationToken cancellationToken)
        {
            await _accountService.UpdateAsync(accounts, cancellationToken);
            return NoContent();
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> PatchAsync(string id, [FromBody] AccountUpdate account, CancellationToken cancellationToken)
        {
            await _accountService.UpdateAsync(id, account, cancellationToken);
            return NoContent();
        }

        [Route("composite")]
        [HttpGet]
        public async Task<IActionResult> CompositeAsync([FromQuery(Name = "ids")]IEnumerable<string> ids, CancellationToken cancellationToken)
        {
            var accounts = await _accountService.GetCompositeAsync(ids, cancellationToken);

            return Ok(accounts);
        }
    }
}