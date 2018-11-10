using System.Collections.Generic;

namespace DomainModels.Models
{
    public class KeyPhraseModel
    {
        public Dictionary<string, int> Dict { get; set; }

        public KeyPhraseModel(Dictionary<string,int> dict)
        {
            Dict = dict;
        }
    }
}
