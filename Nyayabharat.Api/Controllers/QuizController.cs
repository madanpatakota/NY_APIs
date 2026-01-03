using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nyayabharat.Application.Interfaces.Services;

namespace Nyayabharat.Api.Controllers
{
    [ApiController]
    [Route("api/quiz")]
    [Authorize] // quiz must be authenticated
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;

        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        // =========================================
        // START SITUATION-BASED QUIZ
        // GET: /api/quiz/situation/{situationId}/{difficulty}
        // =========================================
        [HttpGet("situation/{situationId:int}/{difficulty}")]
        public async Task<IActionResult> StartSituationQuiz(
            int situationId,
            string difficulty)
        {
            var userType = User.FindFirst("UserType")?.Value;

            if (string.IsNullOrEmpty(userType))
                return Unauthorized("UserType missing");

            var questions = await _quizService
                .StartSituationQuizAsync(
                    situationId,
                    difficulty,
                    userType
                );

            return Ok(questions);
        }

        // =========================================
        // START SECTION-BASED QUIZ
        // GET: /api/quiz/section/{sectionId}/{difficulty}
        // =========================================
        [HttpGet("section/{sectionId:int}/{difficulty}")]
        public async Task<IActionResult> StartSectionQuiz(
            int sectionId,
            string difficulty)
        {
            var userType = User.FindFirst("UserType")?.Value;

            if (string.IsNullOrEmpty(userType))
                return Unauthorized("UserType missing");

            var questions = await _quizService
                .StartSectionQuizAsync(
                    sectionId,
                    difficulty,
                    userType
                );

            return Ok(questions);
        }

        // =========================================
        // SUBMIT QUIZ
        // POST: /api/quiz/submit/{attemptId}
        // =========================================
        [HttpPost("submit/{attemptId:int}")]
        public async Task<IActionResult> SubmitQuiz(
            int attemptId,
            [FromBody] Dictionary<int, int> answers)
        {
            if (answers == null || !answers.Any())
                return BadRequest("Answers are required");

            var result = await _quizService
                .SubmitQuizAsync(attemptId, answers);

            return Ok(result);
        }
    }
}
