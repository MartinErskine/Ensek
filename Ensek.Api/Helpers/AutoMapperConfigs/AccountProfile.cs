using AutoMapper;
using Ensek.Api.Models.Account;
using Ensek.Data.Entities;

namespace Ensek.Api.Helpers.AutoMapperConfigs
{
    /// <summary>
    /// 
    /// </summary>
    public class AccountProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public AccountProfile()
        {
            CreateMap<Account, AccountModel>().ReverseMap();
            CreateMap<Account, AccountPostModel>();
        }
    }
}
