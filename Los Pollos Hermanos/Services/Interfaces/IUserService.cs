using Los_Pollos_Hermanos.ApiModels;
using Los_Pollos_Hermanos.ApiModels.Pagination.Models;


namespace Los_Pollos_Hermanos.Services.Interfaces
{
    public interface IUserService: IBaseService<UserApiModel>
    {
        Task<UserApiModel> GetUserByUserEmail(string email);
    }
}
