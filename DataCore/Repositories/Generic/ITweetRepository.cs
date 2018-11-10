using DataDomain.DataModel;
using System;
using System.Collections.Generic;

namespace DataCore.Repositories.Generic
{
    public interface ITweetRepository
    {
        List<Tweet> GetAll();

        void Update(Tweet entity);

        List<Tweet> GetByDateAndHashtag(DateTime date, string hashtag);

        Tweet GetByTweetId(long id);

        void SaveChanges();
    }
}
