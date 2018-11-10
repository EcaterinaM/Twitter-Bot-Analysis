using DataCore.Respositories.Generic;
using DataDomain.DataModel;
using DataPersistance.Context;
using System;

namespace DataCore.Repositories.Implementation
{
    public class BaseRepository<T>
        : IBaseRepository<T> where T : BaseModel
    {
        private readonly DatabaseContext _databaseContext;

        public BaseRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Add(T entity)
        {
            _databaseContext.Set<T>().Add(entity);
            //_databaseContext.SaveChanges();
        }

        public async System.Threading.Tasks.Task AddAsync(T entity)
        {
            await _databaseContext.AddAsync(entity);
            await _databaseContext.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            _databaseContext.Set<T>().Remove(entity);
            _databaseContext.SaveChanges();
        }

        public void Edit(T entity)
        {
            _databaseContext.Set<T>().Update(entity);
            _databaseContext.SaveChanges();
        }

        public T GetById(Guid id)
        {
            return _databaseContext.Set<T>().Find(id);
        }

        public void Save()
        {
            _databaseContext.SaveChanges();
        }
     
    }
}
