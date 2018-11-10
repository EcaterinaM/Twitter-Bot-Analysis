using DataDomain.DataModel;
using System;
using System.Threading.Tasks;

namespace DataCore.Respositories.Generic
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        void Add(T entity);

        Task AddAsync(T entity);

        void Delete(T entity);

        T GetById(Guid id);

        void Edit(T entity);

        void Save();
    }
}
