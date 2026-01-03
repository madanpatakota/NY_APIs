using Nyayabharat.Application.DTOs.Quiz;
using Nyayabharat.Application.Interfaces.Repositories;
using Nyayabharat.Application.Interfaces.Services;
using Nyayabharat.Domain.Entities;
using Nyayabharat.Domain.Enums;

namespace Nyayabharat.Application.Services
{
    public class QuizService : IQuizService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IQuizAttemptRepository _attemptRepository;
        private readonly IQuizAttemptAnswerRepository _answerRepository;

        public QuizService(
            IQuestionRepository questionRepository,
            IQuizAttemptRepository attemptRepository,
            IQuizAttemptAnswerRepository answerRepository)
        {
            _questionRepository = questionRepository;
            _attemptRepository = attemptRepository;
            _answerRepository = answerRepository;
        }

        // ================================
        // START SITUATION QUIZ
        // ================================
        public async Task<IEnumerable<QuizQuestionDto>> StartSituationQuizAsync(
            int situationId,
            string difficulty,
            string userType)
        {
            var parsedUserType = Enum.Parse<UserType>(userType, true);

            var questions = await _questionRepository
                .GetQuizQuestionsBySituationAsync(
                    situationId,
                    difficulty,
                    parsedUserType);

            return MapToDto(questions);
        }

        // ================================
        // START SECTION QUIZ
        // ================================
        public async Task<IEnumerable<QuizQuestionDto>> StartSectionQuizAsync(
            int sectionId,
            string difficulty,
            string userType)
        {
            var parsedUserType = Enum.Parse<UserType>(userType, true);

            var questions = await _questionRepository
                .GetQuizQuestionsBySectionAsync(
                    sectionId,
                    difficulty,
                    parsedUserType);

            return MapToDto(questions);
        }

        // ================================
        // SUBMIT QUIZ
        // ================================
        public async Task<QuizResultDto> SubmitQuizAsync(
            int attemptId,
            Dictionary<int, int> answers)
        {
            int total = answers.Count;
            int correct = 0;

            var attemptAnswers = new List<QuizAttemptAnswer>();

            foreach (var entry in answers)
            {
                var question = await _questionRepository
                    .GetQuestionWithOptionsAsync(entry.Key);

                if (question == null) continue;

                var selected = question.Options
                    .FirstOrDefault(o => o.OptionId == entry.Value);

                bool isCorrect = selected != null && selected.IsCorrect;

                if (isCorrect) correct++;

                attemptAnswers.Add(new QuizAttemptAnswer
                {
                    AttemptId = attemptId,
                    QuestionId = entry.Key,
                    SelectedOptionId = entry.Value,
                    IsCorrect = isCorrect
                });
            }

            await _answerRepository.AddAnswersAsync(attemptAnswers);

            var attempt = await _attemptRepository.GetByIdAsync(attemptId);

            if (attempt != null)
            {
                attempt.CompletedOn = DateTime.UtcNow;
                attempt.CorrectAnswers = correct;
                attempt.Score = total == 0 ? 0 : (correct * 100) / total;

                await _attemptRepository.UpdateAttemptAsync(attempt);
            }

            return new QuizResultDto
            {
                AttemptId = attemptId,
                TotalQuestions = total,
                CorrectAnswers = correct,
                Score = total == 0 ? 0 : (correct * 100) / total
            };
        }

        // ================================
        // PRIVATE MAPPER
        // ================================
        private static IEnumerable<QuizQuestionDto> MapToDto(
            IEnumerable<Domain.Entities.Question> questions)
        {
            return questions.Select(q => new QuizQuestionDto
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
    }
}
