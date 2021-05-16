using System.Collections.Generic;
using System.Threading.Tasks;
using Ensek.Api.Interfaces;
using Ensek.Api.Models.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ensek.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "AccountApi")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        /// <summary>
        /// 
        /// </summary>
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<AccountModel>>> GetAccounts()
        {
            var response = await _accountService.GetAccounts();

            if (response.IsError)
            {
                return StatusCode((int)response.ErrorCode, response.ErrorDescription);
            }

            return Ok(response.Data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [HttpGet("{accountId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<AccountModel>> GetAccount(int accountId)
        {
            var response = await _accountService.GetAccount(accountId);

            if (response.IsError)
            {
                return StatusCode((int)response.ErrorCode, response.ErrorDescription);
            }

            return Ok(response.Data);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<AccountModel>> PostAccount(AccountPostModel accountPostModel)
        {



            return Ok();
        }


    }
}
