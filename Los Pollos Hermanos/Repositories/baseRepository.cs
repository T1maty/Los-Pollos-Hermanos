using Los_Pollos_Hermanos.Models.Interfaces;
using Los_Pollos_Hermanos.Repositories.Interfaces;

namespace Los_Pollos_Hermanos.Repositories
{
    public class baseRepository<TModel> : IBaseRepository<TModel> where TModel : class, IBaseModel
    {
        public Task<TModel> CreateAsync(TModel model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TModel>> CreateRangeAsync(ICollection<TModel> models)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRangeAsync(IEnumerable<TModel> entities)
        {
            throw new NotImplementedException();
        }

        public Task<List<TModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<TModel>> GetAllAsync(Func<TModel, bool> filter)
        {
            throw new NotImplementedException();
        }

        public Task<TModel> GetByAsync(Func<TModel, bool> filter)
        {
            throw new NotImplementedException();
        }

        public Task<TModel> UpdateAsync(TModel model)
        {
            throw new NotImplementedException();
        }


        protected readonly ILogger<baseRepository<TModel>> _logger;
        protected readonly 
    }
}
