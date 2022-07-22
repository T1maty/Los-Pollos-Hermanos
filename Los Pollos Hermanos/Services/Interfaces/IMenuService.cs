using Los_Pollos_Hermanos.ApiModels;
using Los_Pollos_Hermanos.ApiModels.Pagination.Models;

namespace Los_Pollos_Hermanos.Services.Interfaces
{
    public interface IMenuService : IBaseService<MenuApiModel>
    {
        Task<PagedResult<MenuApiModel>> GetMenusByUser(int Id, BasePageModel model);
    }
}
