using Cqrs.Queries.Interfaces;
using DomainModels.Models.User;
using System.Collections.Generic;

namespace BusinessLayerCqrs.CQRS.Queries.QueryResult
{
    public class GetUserInformationQueryResult : IQueryResult
    {
        public List<UserModel> UserModelList { get; set; }

        public GetUserInformationQueryResult(List<UserModel> list)
        {
            UserModelList = list ;
        }
    }
}
