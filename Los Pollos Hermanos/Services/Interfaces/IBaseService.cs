using Los_Pollos_Hermanos.ApiModels;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Los_Pollos_Hermanos.Services.Interfaces
{
    public interface IBaseService<T>
    {
        Task<CreateUpdate<T>> CreateAsync(T model);
        Task<List<CreateUpdate<T>>> CreateRangeAsync(List<T> models);
        Task<CreateUpdate<T>> UpdateAsync(T model);
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<bool> DeleteAsync(int id);
        Task<UserApiModel> GetUserByUserEmail(string email);
    }
}
