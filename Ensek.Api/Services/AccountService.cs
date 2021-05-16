using Ensek.Api.Helpers;
using Ensek.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Ensek.Api.Interfaces;
using Ensek.Api.Models.Account;
using Microsoft.EntityFrameworkCore;

namespace Ensek.Api.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class AccountService : IAccountService
    {
        private readonly EnsekDbContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public AccountService(EnsekDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResponse<List<AccountModel>>> GetAccounts()
        {
            try
            {
                var accounts = await _context.Accounts.ToListAsync();

                if (accounts.Any())
                {
                    return new ServiceResponse<List<AccountModel>>
                    {
                        Data = _mapper.Map<List<AccountModel>>(accounts)
                    };
                }

                return new ServiceResponse<List<AccountModel>>();
            }
            catch (Exception e)
            {
                return new ServiceResponse<List<AccountModel>>
                {
                    ErrorCode = HttpStatusCode.InternalServerError,
                    ErrorDescription = "Internal Server Error"
                };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<AccountModel>> GetAccount(int accountId)
        {
            try
            {
                var account = await _context.Accounts.FirstOrDefaultAsync(f => f.AccountId == accountId);

                if (account != null)
                {
                    return new ServiceResponse<AccountModel>
                    {
                        Data = _mapper.Map<AccountModel>(account)
                    };
                }

                return new ServiceResponse<AccountModel>();
            }
            catch (Exception e)
            {
                return new ServiceResponse<AccountModel>
                {
                    ErrorCode = HttpStatusCode.InternalServerError,
                    ErrorDescription = "Internal Server Error"
                };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountPostModel"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<AccountModel>> PostAccount(AccountPostModel accountPostModel)
        {
            try
            {
                //TODO: Create POST logic.
                //



                return null;
            }
            catch (Exception e)
            {
                return new ServiceResponse<AccountModel>
                {
                    ErrorCode = HttpStatusCode.InternalServerError,
                    ErrorDescription = "Internal Server Error"
                };
            }
        }
    }
}
