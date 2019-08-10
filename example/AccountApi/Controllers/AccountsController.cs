using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AccountApi.Models;
using AccountApi.Services;
using Microsoft.AspNetCore.Mvc;
using Reinforce.RestApi;

namespace AccountApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ISObjectBasicInformation _sObjectBasicInformation;

        public AccountsController(IAccountService accountService, ISObjectBasicInformation sObjectBasicInformation)
        {
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
            _sObjectBasicInformation = sObjectBasicInformation ?? throw new ArgumentNullException(nameof(sObjectBasicInformation));
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

        [HttpPost]
        public Task PostAsync([FromBody] Account account, CancellationToken cancellationToken)
        {
            return _sObjectBasicInformation.PostAsync(nameof(Account), account, cancellationToken);
        }
    }
}