using System.Collections.Generic;
using System.Threading.Tasks;
using Ensek.Api.Helpers;
using Ensek.Api.Models.Account;

namespace Ensek.Api.Interfaces
{
    public interface IAccountService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<ServiceResponse<List<AccountModel>>> GetAccounts();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        Task<ServiceResponse<AccountModel>> GetAccount(int accountId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountPostModel"></param>
        /// <returns></returns>
        Task<ServiceResponse<AccountModel>> PostAccount(AccountPostModel accountPostModel);
    }
}