using BusinessLayerCqrs.CQRS.Commands.Command;
using Cqrs.Commands.Interfaces;
using DataCore.Repositories.Generic;
using DataCore.Respositories.Generic;
using DataDomain.DataModel;
using System;

namespace BusinessLayerCqrs.CQRS.Commands.CommandHandler
{
    public class AddUserInformationCommandHandler : ICommandHandler<AddUserInformationCommand>
    {
        private readonly IBaseRepository<UserInformation> _userInformationRepository;

        private readonly IUserInformationRepository _userRepository;

        public AddUserInformationCommandHandler(IBaseRepository<UserInformation> userInformationRepository,
            IUserInformationRepository userRepository)
        {
            _userRepository = userRepository;
            _userInformationRepository = userInformationRepository;
        }

        public void Execute(AddUserInformationCommand command)
        {


            var userModel = new UserInformation()
            {
                AccountActivity = command.userModel.AccountActivity,
                AccountAnonimity = command.userModel.AccountAnonimity,
                DaysActiveAccount = command.userModel.DaysActiveAccount,
                TweetUsername = command.userModel.ScreenName,
                TimelineDecision = command.userModel.TimelineModel.TimelineDecision,
                NumberOfGeneratedUrls = command.userModel.TimelineModel.NumberOfGeneratedUrls,
                NumberOfRetweetsFromTimeline = command.userModel.TimelineModel.NumberOfRetweetsFromTimeline,
                NumberOfTweets = command.userModel.NumberOfTweets,
                NumberOfTweetsFromTimeline = command.userModel.TimelineModel.NumberOfTweetsFromTimeline,
                RetweetsCounter = command.userModel.TimelineModel.RetweetsCounter,
                CollectedTweetsFromTimeline = command.userModel.TimelineModel.CollectedTweetsFromTimeline,
                IsBot = command.userModel.IsBot,
                TweetUserId = command.userModel.TweetUserId,
                Id = Guid.NewGuid()
            };

            var userFound = _userRepository.GetByUsername(command.userModel.ScreenName);
            if( userFound == null)
            {
                _userInformationRepository.Add(userModel);

            }
            _userInformationRepository.Save();
        }
    }
}
