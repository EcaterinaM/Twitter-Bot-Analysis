using Cqrs.Queries.Interfaces;
using DomainModels.Models.User;

namespace BusinessLayerCqrs.CQRS.Queries.QueryResult
{
    public class GetUserInformationByUsernameQueryResult : IQueryResult
    {
        public UserModel UserModel { get; set; }

        public GetUserInformationByUsernameQueryResult(UserModel userModel)
        {
            UserModel = userModel;
        }
    }
}
