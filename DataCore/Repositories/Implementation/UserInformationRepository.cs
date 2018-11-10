using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataCore.Repositories.Generic;
using DataCore.Respositories.Generic;
using DataDomain.DataModel;
using DataPersistance.Context;

namespace DataCore.Repositories.Implementation
{
    public class UserInformationRepository : IBaseRepository<UserInformation>, IUserInformationRepository
    {
        private readonly DatabaseContext _databaseContext;

        public UserInformationRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Add(UserInformation entity)
        {
            _databaseContext.Add(entity);
        }

        public Task AddAsync(UserInformation entity)
        {
           return  _databaseContext.AddAsync(entity);
        }

        public void Delete(UserInformation entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(UserInformation entity)
        {
            throw new NotImplementedException();
        }

        public List<UserInformation> GetAll()
        {
            return _databaseContext.UserInformation.ToList();
        }

        public UserInformation GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public UserInformation GetByUsername(string username)
        {
            return _databaseContext.UserInformation
                    .FirstOrDefault(u => u.TweetUsername.Equals(username));
        }

        public void Save()
        {
            _databaseContext.SaveChanges();
        }
    }
}
