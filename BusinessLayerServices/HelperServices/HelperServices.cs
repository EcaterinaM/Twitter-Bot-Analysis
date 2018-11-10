using BusinessLayerServices.AzureServices.Interfaces;
using DomainModels.Models;
using DomainModels.Models.Azure;
using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using System;
using System.Collections.Generic;

namespace BusinessLayerServices.HelperServices
{
    public class HelperServices : IHelperService
    {
        private readonly IAzureServices _azureService;

        public HelperServices(IAzureServices azureService)
        {
            _azureService = azureService;
        }

        public Dictionary<string, int> GetTopKeyPhrases(List<LanguageModel> listOfStrings)
        {
            var keyPhrases = _azureService.GetKeyPhraseList(listOfStrings);

            var dict = new Dictionary<string, int>();

            foreach (var kp in keyPhrases.Documents)
            {
                for (int i = 0; i < kp.KeyPhrases.Count; i++)
                {
                    var keys = dict.Keys;

                    if (dict.ContainsKey(kp.KeyPhrases[i]))
                    {
                        dict[kp.KeyPhrases[i]] = dict.GetValueOrDefault(kp.KeyPhrases[i]) + 1;
                    }
                    else
                    {
                        dict[kp.KeyPhrases[i]] = 0;
                    }
                }
            }

            return dict;

        }


        public List<NewsModel> GetListNews(string keyphrase, DateTime fromDate)
        {
            var newsApiClient = new NewsApiClient("c3eb90f31b2946d29c9ffca8cd9c2626");
            var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            {
                Q = keyphrase,
                SortBy = SortBys.Popularity,
                Language = Languages.EN,
                From = fromDate
            });

            var list = new List<NewsModel>();
            for(var i = 0; i < 8; i++)
            {
                var news = new NewsModel()
                {
                    Title = articlesResponse.Articles[i].Title,
                    Url = articlesResponse.Articles[i].Url,
                    From = articlesResponse.Articles[i].Source.Name
                };
                list.Add(news);
            }

           return list;
        }
    }
}

