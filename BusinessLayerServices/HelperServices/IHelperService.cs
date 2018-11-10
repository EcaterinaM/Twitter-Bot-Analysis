using DomainModels.Models;
using DomainModels.Models.Azure;
using System;
using System.Collections.Generic;

namespace BusinessLayerServices.HelperServices
{
    public interface IHelperService
    {

        Dictionary<string, int> GetTopKeyPhrases(List<LanguageModel> listOfStrings);

        List<NewsModel> GetListNews(string keyphrase, DateTime fromDate);
    }
}
