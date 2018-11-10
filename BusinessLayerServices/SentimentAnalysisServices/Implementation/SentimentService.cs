using BusinessLayerServices.SentimentAnalysisServices.Interfaces;
using Common.Helpers;
using DomainModels.Enums;
using DomainModels.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Tweetinvi.Models;

namespace BusinessLayerServices.SentimentAnalysisServices.Implementation
{
    public class SentimentService : ISentimentService
    {
        /// <summary>
        /// Method to get the sentiment analysis for a text received as parameter.
        /// </summary>
        /// <param name="textToEvaluate"> Text received as parameter.</param>
        /// <returns> Sentiment Object Model.</returns>
        public async Task<SentimentObjectModel> GetSentimentAnalysisForTextAsync(string textToEvaluate)
        {
            var jsonArrayToSend = new JArray();
            jsonArrayToSend.Add(new JObject(new JProperty(StringConstants.TextJsonProperty, textToEvaluate)));

            var objectToAdd = new JObject(new JProperty(StringConstants.ArrayJsonProperty, jsonArrayToSend));
            var myContent = JsonConvert.SerializeObject(jsonArrayToSend);

            var httpClient = new HttpClient();
            var httpContent = new StringContent(objectToAdd.ToString());

            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(StringConstants.ApplicationJsonMediaTypeHeaderValue);
            var response = await httpClient.PostAsync(StringConstants.UriSentimentApi, httpContent);

            if (!response.IsSuccessStatusCode)
            {
                throw new ArgumentException("Sentiment API doesn't work");
            }

            var contents = await response.Content.ReadAsStringAsync();

            var resultJson = JObject.Parse(contents);
            var resultValue = resultJson.GetValue(StringConstants.ArrayJsonProperty);

            var polarity = int.Parse(resultValue[0][StringConstants.PolarityJsonProperty].ToString());
            var sentimentObjectModel = new SentimentObjectModel
            {
                Text = textToEvaluate,
                Polarity = polarity,
                SentimentType = Enum.GetName(typeof(SentimentTypesEnum), polarity)
            };

            return sentimentObjectModel;
        }

        /// <summary>
        /// Method to get a list of SentimentObjectModel with the sentiment for a list of text.
        /// </summary>
        /// <param name="listOfTexts"></param>
        /// <returns></returns>
        public IList<SentimentObjectModel> GetSentimentAnalysisForAListOfTextAsync(IList<ITweet> listOfTexts)
        {
            var resultList = new List<SentimentObjectModel>();

            foreach (var item in listOfTexts)
            {
                var sentiment = GetSentimentAnalysisForTextAsync(item.Text);
                resultList.Add(sentiment.Result);
            }
            return resultList;
           
        }
    }
}
