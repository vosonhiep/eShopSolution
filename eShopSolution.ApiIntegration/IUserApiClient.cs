using eShopSolution.ViewModels.Catalog.Common;
using eShopSolution.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.AdminApp.Models.Services
{
    public interface IUserApiClient
    {
        public Task<ApiResult<string>> Authenticate(LoginRequest request);
        public Task<ApiResult<PageResult<UserViewModel>>>GetUsersPaging(GetUserPagingRequest request);
        public Task<ApiResult<bool>> RegisterUser(RegisterRequest registerRequest);
        public Task<ApiResult<UserViewModel>> GetById(Guid id);
        public Task<ApiResult<bool>> UpdateUser(Guid id, UserUpdateRequest request);
        public Task<ApiResult<bool>> DeleteUser(Guid id);
        public Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request);
    }
}
