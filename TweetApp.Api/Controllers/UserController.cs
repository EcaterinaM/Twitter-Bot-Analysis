using BusinessLayerCqrs.CQRS.Commands.Command;
using BusinessLayerCqrs.CQRS.Queries.Query;
using BusinessLayerCqrs.CQRS.Queries.QueryResult;
using BusinessLayerServices.TwitterServices;
using BusinessLayerServices.TwitterServices.Interfaces;
using Cqrs.Commands.Interfaces;
using Cqrs.Queries.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TweetApp.Api.Controllers
{
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly ITwitterDataService _twitterService;

        private readonly ITwitterUserService _twitterUserService;

        private readonly ICommandDispatcher _commandDisptacher;

        private readonly IQueryDispatcher _queryDispatcher;

        public UserController(ITwitterDataService twitterService,
             ITwitterUserService twitterUserService,
             ICommandDispatcher commandDispatcher,
             IQueryDispatcher queryDispatcher)
        {
            _twitterService = twitterService;
            _twitterUserService = twitterUserService;
            _commandDisptacher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            var result = _queryDispatcher.Execute<GetUserInformationQuery, GetUserInformationQueryResult>(new GetUserInformationQuery());
            return Ok(result);
        }

        [HttpGet("{username}/username")]
        public IActionResult GetUserInformation(string username)
        {
            var user = _twitterUserService.GetScreenNameInformation(username);
            return Ok(user);
        }

        [HttpGet("{username}/anonimity")]
        public IActionResult Get(string username)
        {
            _twitterUserService.DetermineAccountAnonimity(username);
            return Ok();
        }

        [HttpGet("{username}/activity")]
        public IActionResult GetActivityType(string username)
        {
            _twitterUserService.DetermineAccountActivity(username);
            return Ok();
        }

        [HttpGet("{username}/timeline")]
        public IActionResult GetTimeline(string username)
        {
            return Ok(_twitterUserService.DetermineAccountTimeline(username));
        }


        [HttpGet("{username}/bot")]
        public IActionResult GetIfBot(string username)
        {
            var userByUsername = _queryDispatcher.Execute<GetUserInformationByUsernameQuery,
                GetUserInformationByUsernameQueryResult>(new GetUserInformationByUsernameQuery(username));
            if (userByUsername == null)
            {
                var user = _twitterUserService.DetermineBotAnalysis(username);
                var command = new AddUserInformationCommand(user);
                _commandDisptacher.Execute(command);
                return Ok(user);
            }
            return Ok(userByUsername.UserModel);
        }

        [HttpGet("bot/history")]
        public IActionResult GetHistoryBot(string username)
        {
            var list = _queryDispatcher
                .Execute<GetUserInformationQuery, GetUserInformationQueryResult>(new GetUserInformationQuery());
            return Ok(list.UserModelList);
        }

        [HttpGet("{username}/{numberOfFollowers}/followers")]
        public IActionResult GetFollowers(string username, int numberOfFollowers)
        {
            return Ok(_twitterUserService.DetermineFollowersType(username, numberOfFollowers));
        }
    }
}
