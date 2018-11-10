using Cqrs.Queries.Interfaces;
using DomainModels.Models.User;
using System.Collections.Generic;

namespace BusinessLayerCqrs.CQRS.Queries.QueryResult
{
    public class GetUserInformationHistoryQueryResult : IQueryResult
    {
        public IList<UserModel> UserModelList { get; set; }

        public GetUserInformationHistoryQueryResult(IList<UserModel> userModelList)
        {
            UserModelList = userModelList;
        }
    }
}
