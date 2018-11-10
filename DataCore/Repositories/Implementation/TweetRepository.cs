using System;
using System.Collections.Generic;
using System.Linq;
using DataCore.Repositories.Generic;
using DataDomain.DataModel;
using DataPersistance.Context;

namespace DataCore.Repositories.Implementation
{
    public class TweetRepository : BaseRepository<Tweet>, ITweetRepository
    {
        private readonly DatabaseContext _databaseContext;

        public TweetRepository(DatabaseContext databaseContext)
            : base(databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<Tweet> GetAll()
        {
            return _databaseContext.TweetModel.ToList();
        }

        public List<Tweet> GetByDateAndHashtag(DateTime date, string hashtag)
        {
            return _databaseContext.TweetModel
                        .Where(t => t.TweetDate.Date.Equals(date.Date)
                            & t.HashtagSearchValue.Equals(hashtag)).ToList();
        }

        public Tweet GetByTweetId(long id)
        {
            return _databaseContext.TweetModel.FirstOrDefault(x => x.TweetId == id);
        }

        public void SaveChanges()
        {
            _databaseContext.SaveChanges();
        }

        public void Update(Tweet entity)
        {
            _databaseContext.TweetModel.Update(entity);
        }

    }
}
