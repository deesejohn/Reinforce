using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AccountApi.Models;
using AccountApi.Services;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<Account>> GetAsync(string id, CancellationToken cancellationToken)
        {
            var account = await _accountService.ReadAsync(id, cancellationToken);
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }

        [HttpPatch("{id}")]
        public Task PatchAsync(string id, [FromBody] AccountUpdate account, CancellationToken cancellationToken)
        {
            return _accountService.UpdateAsync(id, account, cancellationToken);
        }
    }
}