using AutoMapper;
using BusinessLayerCqrs.CQRS.Queries.Query;
using BusinessLayerCqrs.CQRS.Queries.QueryResult;
using Cqrs.Queries.Interfaces;
using DataCore.Repositories.Generic;
using DataCore.Respositories.Generic;
using DataDomain.DataModel;
using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayerCqrs.CQRS.Queries.QueryHandler
{
    public class GetTweetByDateAndHashtagQueryHandler : IQueryHandler<GetTweetByDateAndHashtagQuery, GetTweetByDateAndHashtagQueryResult>
    {
        private readonly ITweetRepository _tweetRepository;
        private readonly IMapper _mapper;

        public GetTweetByDateAndHashtagQueryHandler(ITweetRepository tweetRepository,
            IMapper mapper)
        {
            _tweetRepository = tweetRepository;
            _mapper = mapper;
        }

        public GetTweetByDateAndHashtagQueryResult Execute(GetTweetByDateAndHashtagQuery query)
        {
            var date = query.Date;
            var hashtag = query.Hashtag;
            var list = _tweetRepository.GetByDateAndHashtag(date, hashtag).ToList();
            var tweetModelList = _mapper.Map<List<Tweet>, List<TweetModel>>(list);
            return new GetTweetByDateAndHashtagQueryResult(tweetModelList);

        }
    }
}
