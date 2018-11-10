using BusinessLayerCqrs.CQRS.Queries.QueryResult;
using Cqrs.Queries.Interfaces;

namespace BusinessLayerCqrs.CQRS.Queries.Query
{
    public class GetUserInformationByUsernameQuery : IQuery<GetUserInformationByUsernameQueryResult>
    {
        public string Username { get; set; }

        public GetUserInformationByUsernameQuery(string username)
        {
            Username = username;
        }
    }
}
