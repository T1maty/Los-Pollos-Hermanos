using Los_Pollos_Hermanos.ApiModels;
using Los_Pollos_Hermanos.ApiModels.Pagination.Models;


namespace Los_Pollos_Hermanos.Services.Interfaces
{
    public interface IUserService: IBaseService<UserApiModel>
    {
        Task<UserApiModel> GetUserByUserEmail(string email);
        Task<UserApiModel> GetUderByUserId(string id);
        Task<PagedResult<UserApiModel>> GetPageUser(BasePageModel model);
        Task<List<string>> GetUserRolesById(int userId);
        Task<List<string>> GetAllRoles();
        Task<bool> UpdateUserRoles(int userId, IEnumerable<string> roles);
        Task<PagedResult<UserApiModel>> GetUsersByRoleName(string roleName, BasePageModel model);
    }
}
