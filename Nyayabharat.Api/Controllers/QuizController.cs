using Microsoft.AspNetCore.Mvc;
using Nyayabharat.Application.Interfaces.Services;

namespace Nyayabharat.Api.Controllers
{
    [ApiController]
    [Route("api/quiz")]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;

        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }




        //Endpoint to start a quiz http://https://localhost:7156/api/quiz/start/{situationId}/{difficulty}
        [HttpGet("start/{situationId}/{difficulty}")]
        public async Task<IActionResult> Start(int situationId, string difficulty)
        {
            var questions = await _quizService.StartQuizAsync(situationId, difficulty);
            return Ok(questions);
        }

        //Endpoint to submit quiz answers http://https://localhost:7156/api/quiz/submit/{attemptId}
        [HttpPost("submit/{attemptId}")]
        public async Task<IActionResult> Submit(int attemptId, [FromBody] Dictionary<int, int> answers)
        {
            var result = await _quizService.SubmitQuizAsync(attemptId, answers);
            return Ok(result);
        }
    }
}
