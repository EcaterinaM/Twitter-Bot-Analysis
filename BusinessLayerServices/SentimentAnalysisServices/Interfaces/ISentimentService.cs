using DomainModels.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tweetinvi.Models;

namespace BusinessLayerServices.SentimentAnalysisServices.Interfaces
{
    public interface ISentimentService
    {
        Task<SentimentObjectModel> GetSentimentAnalysisForTextAsync(string text);

        IList<SentimentObjectModel> GetSentimentAnalysisForAListOfTextAsync(IList<ITweet> listOfTexts);

    }
}
