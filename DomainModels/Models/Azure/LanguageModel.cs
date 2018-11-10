namespace DomainModels.Models.Azure
{
    public class LanguageModel
    {
        public string Language { get; set; }

        public string Text { get; set; }

        public LanguageModel(string language, string text)
        {
            Language = language;
            Text = text;
        }
    }
}
