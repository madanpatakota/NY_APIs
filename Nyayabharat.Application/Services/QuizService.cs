using Nyayabharat.Application.DTOs.Quiz;
using Nyayabharat.Application.Interfaces.Repositories;
using Nyayabharat.Application.Interfaces.Services;
using Nyayabharat.Domain.Entities;

namespace Nyayabharat.Application.Services
{
    public class QuizService : IQuizService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IQuizAttemptRepository _attemptRepository;
        private readonly IUserProgressRepository _progressRepository;

        public QuizService(
            IQuestionRepository questionRepository,
            IQuizAttemptRepository attemptRepository,
            IUserProgressRepository progressRepository)
        {
            _questionRepository = questionRepository;
            _attemptRepository = attemptRepository;
            _progressRepository = progressRepository;
        }

        public async Task<IEnumerable<QuizQuestionDto>> StartQuizAsync(int situationId, string difficulty)
        {
            var questions = await _questionRepository.GetQuestionsBySituationIdAsync(situationId);

            return questions
                .Where(q => q.Difficulty.Equals(difficulty, StringComparison.OrdinalIgnoreCase))
                .Select(q => new QuizQuestionDto
                {
                    QuestionId = q.QuestionId,
                    QuestionText = q.QuestionText,
                    Options = q.Options.Select(o => new QuizOptionDto
                    {
                        OptionId = o.OptionId,
                        OptionText = o.OptionText
                    }).ToList()
                });
        }

        public async Task<QuizResultDto> SubmitQuizAsync(int attemptId, Dictionary<int, int> answers)
        {
            int total = answers.Count;
            int correct = 0;

            foreach (var entry in answers)
            {
                var question = await _questionRepository.GetByIdAsync(entry.Key);
                if (question == null) continue;

                var selected = question.Options.FirstOrDefault(o => o.OptionId == entry.Value);
                if (selected != null && selected.IsCorrect)
                {
                    correct++;
                }
            }

            var score = (int)((double)correct / total * 100);

            var result = new QuizResultDto
            {
                AttemptId = attemptId,
                TotalQuestions = total,
                CorrectAnswers = correct,
                Score = score
            };

            return result;
        }
    }
}
