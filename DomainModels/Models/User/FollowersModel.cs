using System.Collections.Generic;

namespace DomainModels.Models.User
{
    public class FollowersModel
    {
        public IList<UserModel> UserModelList { get; set; }

        public int NumberOfBots { get; set; }

        public int NumberOfFollowersTested { get; set; }


    }
}
