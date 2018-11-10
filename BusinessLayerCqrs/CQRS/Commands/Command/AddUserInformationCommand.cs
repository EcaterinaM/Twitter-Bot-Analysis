using BusinessLayerCqrs.CQRS.Commands.Interfaces;
using DomainModels.Models.User;

namespace BusinessLayerCqrs.CQRS.Commands.Command
{
    public class AddUserInformationCommand : ICommand
    {
        public UserModel userModel;

        public AddUserInformationCommand(UserModel _userModel)
        {
            userModel = _userModel;
        }
    }
}
