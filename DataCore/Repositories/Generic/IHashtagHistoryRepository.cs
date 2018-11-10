using DataDomain.DataModel;
using System.Collections.Generic;

namespace DataCore.Repositories.Generic
{
    public interface IHashtagHistoryRepository
    {
        IReadOnlyList<HashtagHistory> GetByHashtagValuePaginated(string hashtag, int pageNumber);

        bool CheckIfIsInHashtagHistory(string hashtag);
    }
}
