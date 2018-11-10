using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BusinessLayerServices.AzureServices.Interfaces;

namespace TweetApp.Api.Controllers
{
    [Route("api/azure")]
    public class AzureLanguageController : Controller
    {
        private readonly IAzureServices _azureServices;

        public AzureLanguageController(IAzureServices azureServies)
        {
            _azureServices = azureServies;
        }

        [HttpGet("/language")]
        public IActionResult Get()
        {
            var list = new List<string>
            {
                "I hate you very much",
                "Me gustas tu",
                "Te amo mucho"
            };

            var result = _azureServices.DetectLanguageService(list);
            return Ok(result);
        }

        [HttpGet("/language/{text}")]
        public IActionResult Get(string text)
        {
            var result = _azureServices.DetectLanguageServiceForAString(text);
            return Ok(result);
        }

      
    }
}
