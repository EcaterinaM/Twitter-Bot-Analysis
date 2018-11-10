using BusinessLayerServices.SentimentAnalysisServices.Interfaces;
using DomainModels.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TweetApp.Api.Controllers
{
    [Route("api/sentiment")]
    public class SentimentController : Controller
    {
        private readonly ISentimentService _setimentService;

        public SentimentController(ISentimentService sentimentService)
        {
            _setimentService = sentimentService;
        }

        [HttpPost]
        public async Task<IActionResult> GetSentiment([FromBody] SentimentObjectModel text)
        {
            var result = await _setimentService.GetSentimentAnalysisForTextAsync(text.Text);
            return Ok(result);
        }

        //[HttpGet]
        //public IActionResult GetSentimentList()
        //{
        //    var list = new List<string>
        //    {
        //        "I hate my life",
        //        "I love you",
        //        "Trump is the best president ever",
        //        "I don't care about global worming"
        //    };

        //    var result = _setimentService.GetSentimentAnalysisForAListOfTextAsync(list);
        //    return Ok(result);
        //}

    }
}
