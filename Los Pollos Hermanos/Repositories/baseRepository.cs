using Los_Pollos_Hermanos.Models;
using Los_Pollos_Hermanos.Models.Interfaces;
using Los_Pollos_Hermanos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Los_Pollos_Hermanos.Repositories
{
    public class baseRepository<TModel> : IBaseRepository<TModel> where TModel : class, IBaseModel
    {
      

        protected readonly ILogger<baseRepository<TModel>> _logger;
        protected readonly LosPollosHermanosContext _losPolosHermanosContext;
        protected readonly DbSet<TModel> _dbSet;

        protected baseRepository(LosPollosHermanosContext losPollosHermanosContext,ILogger<baseRepository<TModel>> logger )
        {
            _losPolosHermanosContext = losPollosHermanosContext;
            _logger = logger;
            _dbSet = losPollosHermanosContext.Set<TModel>();
        }
        public virtual async Task<TModel> CreateAsync(TModel model)
        {
            try
            {
                model.Id = 0;
                await _dbSet.AddAsync(model);
                await _losPolosHermanosContext.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public virtual async Task<IEnumerable<TModel>> CreateRamgeAsync(ICollection<TModel>models)
        {
            try
            {
                foreach(var model in models)
                {
                    model.Id = 0;
                }
                await _dbSet.AddRangeAsync(models);
                await _losPolosHermanosContext.SaveChangesAsync();
                return models;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public virtual async Task<TModel> UpdateAsync(TModel model)
        {
            try
            {
                var local = _dbSet
                    .Local
                    .FirstOrDefault(entry => entry.Id.Equals(model.Id));
                if (local != null)
                {
                    _losPolosHermanosContext.Entry(local).State = EntityState.Detached;
                }

                _dbSet.Attach(model);
                _losPolosHermanosContext.Entry(model).State = EntityState.Modified;
                await  _losPolosHermanosContext.SaveChangesAsync();
                return model;
            }
            catch ( Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public virtual async Task<bool> DeleteByIdAsync(int id)
        {
            try
            {
                var found = await _dbSet.FindAsync(id);
                if(found==null)
                    return false;
                _dbSet.Remove(found);
                await _losPolosHermanosContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public virtual Task<TModel> GetByAsync(Func<TModel, bool> filter)
        {
            var res = _dbSet.AsNoTracking().SingleOrDefault(filter);
            return Task.FromResult(res);
        }

        public virtual Task<List<TModel>> GetAllAsync()
        {
            var res = _dbSet.AsNoTracking().ToList();
            return Task.FromResult(res);
        }

        public virtual Task<List<TModel>> GetAllAsync(Func<TModel, bool> filter)
        {
            var res = _dbSet.AsNoTracking().Where(filter).ToList();
            return Task.FromResult(res);
        }

        public Task<IEnumerable<TModel>> CreateRangeAsync(ICollection<TModel> models)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRangeAsync(IEnumerable<TModel> entities)
        {
            throw new NotImplementedException();
        }
    }
}
