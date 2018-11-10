using System.Collections.Generic;
using BusinessLayerServices.AzureServices.Interfaces;
using DomainModels.Models.Azure;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;


namespace BusinessLayerServices.AzureServices.Implementation
{
    public class AzureServices : IAzureServices
    {
        public LanguageBatchResult DetectLanguageService(IList<string> textList)
        {
            ITextAnalyticsAPI client = new TextAnalyticsAPI();
            client.AzureRegion = AzureRegions.Westeurope;
            //SK not valid anymore
            client.SubscriptionKey = "";

            var listInput = new List<Input>();
            for(int i = 0; i < textList.Count; i++)
            {
                var input = new Input(i.ToString(), textList[i]);
                listInput.Add(input);
            }

            LanguageBatchResult result = client.DetectLanguage(new BatchInput(listInput));

            return result;
        }

        public LanguageBatchResult DetectLanguageServiceForAString(string text)
        {
            ITextAnalyticsAPI client = new TextAnalyticsAPI();
            client.AzureRegion = AzureRegions.Westeurope;
            client.SubscriptionKey = "";

            LanguageBatchResult result = client.DetectLanguage(new BatchInput(
                new List<Input>
                {
                    new Input("0", text)
                }));

            return result;
        }

        public KeyPhraseBatchResult GetKeyPhraseList(IList<LanguageModel> list)
        {
            ITextAnalyticsAPI client = new TextAnalyticsAPI();
            client.AzureRegion = AzureRegions.Westeurope;
            client.SubscriptionKey = "";

            var listInput = new List<MultiLanguageInput>();
            for (int i = 0; i < list.Count; i++)
            {
                var language = DetectLanguageServiceForAString(list[i].Text).Documents[0].DetectedLanguages[0].Iso6391Name;
                var input = new MultiLanguageInput(list[i].Language, i.ToString(), list[i].Text);
                listInput.Add(input);
            }

            KeyPhraseBatchResult result2 = client.KeyPhrases(
                new MultiLanguageBatchInput(listInput));

            return result2;
        }

        public KeyPhraseBatchResult GetKeyPhrases()
        {
            ITextAnalyticsAPI client = new TextAnalyticsAPI();
            client.AzureRegion = AzureRegions.Westeurope;
            client.SubscriptionKey = "";

            KeyPhraseBatchResult result2 = client.KeyPhrases(
                    new MultiLanguageBatchInput(
                        new List<MultiLanguageInput>()
                        {
                          new MultiLanguageInput("ja", "1", "猫は幸せ"),
                          new MultiLanguageInput("de", "2", "Fahrt nach Stuttgart und dann zum Hotel zu Fu."),
                          new MultiLanguageInput("en", "3", "My cat is stiff as a rock."),
                          new MultiLanguageInput("es", "4", "A mi me encanta el fútbol!")
                        }));

            return result2;
        }
    }
}
