using DataCore.Repositories.Generic;
using DataDomain.DataModel;
using DataPersistance.Context;
using System.Collections.Generic;
using System.Linq;

namespace DataCore.Repositories.Implementation
{
    public class HashtagHistoryRepository : BaseRepository<HashtagHistory>, IHashtagHistoryRepository
    {
        private readonly DatabaseContext _databaseContext;

        public HashtagHistoryRepository(DatabaseContext databaseContext) 
            : base(databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public bool CheckIfIsInHashtagHistory(string hashtag)
        {
            var entity =_databaseContext.HashtagHistoryModel.FirstOrDefault(x => x.HashtagValue.Equals(hashtag));

            if(entity != null)
            {
                return true;
            }
            return false;
        }

        public IReadOnlyList<HashtagHistory> GetAll()
        {
            return _databaseContext.HashtagHistoryModel.ToList();
        }

        public IReadOnlyList<HashtagHistory> GetByHashtagValuePaginated(string hashtag,int pageNumber)
        {
            return _databaseContext.HashtagHistoryModel
                    .Where(h=> h.HashtagValue.Equals(hashtag))
                    .OrderByDescending(h => h.SearchTime)
                    .Skip((4 * pageNumber) - 4)
                    .Take(4)
                    .ToList();
        }
    }
}
