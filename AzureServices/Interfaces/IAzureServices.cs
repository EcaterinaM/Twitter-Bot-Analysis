using DomainModels.Models.Azure;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using System.Collections.Generic;

namespace BusinessLayerServices.AzureServices.Interfaces
{
    public interface IAzureServices
    {
        LanguageBatchResult DetectLanguageService(IList<string> textList);

        LanguageBatchResult DetectLanguageServiceForAString(string text);

        KeyPhraseBatchResult GetKeyPhrases();

        KeyPhraseBatchResult GetKeyPhraseList(IList<LanguageModel> list);
    }
}
