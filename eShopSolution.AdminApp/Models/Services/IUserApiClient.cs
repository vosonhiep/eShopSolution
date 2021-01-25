﻿using eShopSolution.ViewModels.Catalog.Common;
using eShopSolution.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.AdminApp.Models.Services
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);
        Task<PageResult<UserViewModel>>GetUsersPaging(GetUserPagingRequest request);
        Task<bool> RegisterUser(RegisterRequest registerRequest);
    }
}
