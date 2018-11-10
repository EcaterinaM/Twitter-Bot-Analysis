using DataDomain.DataModel;
using System.Collections.Generic;

namespace DataCore.Repositories.Generic
{
    public  interface IUserInformationRepository
    {
        List<UserInformation> GetAll();

        UserInformation GetByUsername(string username);
    }
}
