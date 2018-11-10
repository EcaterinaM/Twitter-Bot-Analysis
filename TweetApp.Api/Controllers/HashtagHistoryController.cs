using BusinessLayerCqrs.CQRS.Commands.Command;
using BusinessLayerCqrs.CQRS.Queries.Query;
using BusinessLayerCqrs.CQRS.Queries.QueryResult;
using BusinessLayerServices.AzureServices.Interfaces;
using BusinessLayerServices.HelperServices;
using Cqrs.Commands.Interfaces;
using Cqrs.Queries.Interfaces;
using DomainModels.Models;
using DomainModels.Models.Azure;
using DomainModels.Models.Twitter;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace TweetApp.Api.Controllers
{
    [Route("api/hashtaghistory/")]
    public class HashtagHistoryController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly IAzureServices _azureServices;
        private readonly IHelperService _helperService;


        public HashtagHistoryController(ICommandDispatcher commandDispatcher,
            IQueryDispatcher queryDispatcher,
            IAzureServices azureServices,
            IHelperService helperService)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
            _azureServices = azureServices;
            _helperService = helperService;
        }

        [HttpPost]
        public IActionResult AddHashtagHistory([FromBody] HashtagHistoryModel model)
        {
            var command = new AddHashtagHistoryCommand(model);
            _commandDispatcher.Execute(command);
            return Ok();
        }

        [HttpGet("{hashtag}/{pageNumber}")]
        public IActionResult GetHashtagHistory(string hashtag, int pageNumber)
        {
            var query = new GetHashtgHistoryQuery(hashtag, pageNumber);

            var result =
              _queryDispatcher.Execute<GetHashtgHistoryQuery, GetHashtagHistoryQueryResult>(query);

            return Ok(result.HashtagHistoryModel);
        }


        [HttpGet("key/{date}/{hashtag}")]
        public IActionResult GetPhrases(DateTime date, string hashtag)
        {
            var query = new GetTweetByDateAndHashtagQuery(date, hashtag);

            var result =
              _queryDispatcher.Execute<GetTweetByDateAndHashtagQuery, GetTweetByDateAndHashtagQueryResult>(query);

            var listOfString = new List<LanguageModel>();
            for (int i = 0; i < result.TweetModelList.Count; i++)
            {
                listOfString.Add(new LanguageModel(result.TweetModelList[i].Language, result.TweetModelList[i].TweetText));
            }

            var dict = _helperService.GetTopKeyPhrases(listOfString);
            var model = new KeyPhraseModel(dict);
            return Ok(model);
        }

        [HttpGet("news")]
        public IActionResult GetNews([FromQuery] string keyphrase,[FromQuery] DateTime fromDate)
        {
            return Ok(_helperService.GetListNews(keyphrase, fromDate));
        }

    }
}
