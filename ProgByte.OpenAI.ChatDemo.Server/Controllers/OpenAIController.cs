using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ProgByte.OpenAI.ChatDemo.Server.Models;
using ProgByte.OpenAI.ChatDemo.Server.Services;
using System.Text.RegularExpressions;

namespace ProgByte.OpenAI.ChatDemo.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OpenAIController : ControllerBase
    {
        private readonly ILogger<OpenAIController> _logger;
        private readonly OpenAIService _openAIService;

        public OpenAIController(ILogger<OpenAIController> logger, OpenAIService openAIService)
        {
            _logger = logger;
            _openAIService = openAIService;
        }

        [HttpPost]
        [Route("postMessage")]
        public async Task<IActionResult> PostMessage([FromBody] MessageRequest request)
        {
            try
            {
                var response = await _openAIService.GetCompletionAsync(request.Messages);

                return Ok($"\"{response}\"");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return Ok();
        }
    }
}
