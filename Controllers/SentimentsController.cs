using AI_Apps.Models;
using AI_Apps.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AI_Apps.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SentimentsController : ControllerBase
    {
        private readonly ISentimentService _sentimentService;


        //we are injecting sentimentservices using DI
        public SentimentsController(ISentimentService sentimentService)
        {
            _sentimentService = sentimentService;
        }

        [HttpGet("{sentence}")]
        public IEnumerable<SentimentsResponse> Get(string sentence)
        {
            return _sentimentService.GetSentiments(sentence);
        }
    }
}
