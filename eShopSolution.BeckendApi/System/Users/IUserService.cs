using eShopSolution.ViewModels.Catalog.Common;
using eShopSolution.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.BeckendApi.System.Users
{
    public interface IUserService
    {
        Task<string> Authencate(LoginRequest request);
        Task<bool> Register(RegisterRequest request);
        Task<PageResult<UserViewModel>> GetUsersPaging(GetUserPagingRequest request);
    }
}
