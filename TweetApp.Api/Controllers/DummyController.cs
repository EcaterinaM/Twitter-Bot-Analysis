using BusinessLayerServices.AzureServices.Interfaces;
using DataCore.Repositories.Generic;
using DataCore.Respositories.Generic;
using DataDomain.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace TweetApp.Api.Controllers
{
    [Route("api/dummy")]
    public class DummyController: Controller
    {
        private readonly ITweetRepository _tweetRepository;
        private readonly IBaseRepository<Tweet> _baseRepository;
        private readonly IAzureServices _azureService;

        public DummyController(ITweetRepository tweetRepository,
            IAzureServices azureServices,
            IBaseRepository<Tweet> baseRepository)
        {
            _tweetRepository = tweetRepository;
            _azureService = azureServices;
            _baseRepository = baseRepository;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            var list = _tweetRepository.GetAll();

            for (int i = 0; i < list.Count; i++)
            {
                var lan = _azureService.DetectLanguageServiceForAString(list[i].TweetText);
                var language = lan.Documents[0].DetectedLanguages[0].Iso6391Name;

               if(list[i].Language == null)
                {
                    list[i].Language = language;
                    _tweetRepository.Update(list[i]);
                }
            }

            return Ok(list);

        }
    }
}
