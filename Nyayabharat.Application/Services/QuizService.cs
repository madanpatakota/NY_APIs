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
        public async Task<QuizStartResponseDto> StartSituationQuizAsync(
      int situationId,
      string difficulty,
      string userType)
        {
            var parsedUserType = Enum.Parse<UserType>(userType, true);

            var questions = await _questionRepository
                .GetQuizQuestionsBySituationAsync(
                    situationId, difficulty, parsedUserType);

            var list = questions.ToList();

            // ✅ CREATE ATTEMPT (anonymous allowed)
            var attempt = new QuizAttempt
            {
                UserId = 0, // anonymous (login later)
                StartedOn = DateTime.UtcNow,
                Difficulty = difficulty,
                TotalQuestions = list.Count
            };

            await _attemptRepository.AddAttemptAsync(attempt);
            // 🔑 attempt.AttemptId is now available

            var firstQuestion = list.FirstOrDefault();
            var act = firstQuestion?.Section?.Act;

            return new QuizStartResponseDto
            {
                AttemptId = attempt.AttemptId,

                ActId = act?.ActId,
                ActShortName = act?.ActShortName,
                ActName = act?.ActName,

                Questions = MapToDto(list)
            };
        }



        // ================================
        // START SECTION QUIZ
        // ================================
        public async Task<QuizStartResponseDto> StartSectionQuizAsync(
     int sectionId,
     string difficulty,
     string userType)
        {
            var parsedUserType = Enum.Parse<UserType>(userType, true);

            var questions = (await _questionRepository
                .GetQuizQuestionsBySectionAsync(sectionId, difficulty, parsedUserType))
                .ToList();

            if (!questions.Any())
                throw new Exception("No quiz questions found");

            // ✅ CREATE ATTEMPT FIRST
            var attempt = new QuizAttempt
            {
                UserId = null, // anonymous
                StartedOn = DateTime.UtcNow,
                Difficulty = difficulty,
                TotalQuestions = questions.Count
            };

            await _attemptRepository.AddAttemptAsync(attempt);

            var act = questions.First().Section?.Act;

            return new QuizStartResponseDto
            {
                AttemptId = attempt.AttemptId,   // ✅ REAL ID
                ActId = act?.ActId,
                ActShortName = act?.ActShortName,
                ActName = act?.ActName,
                Questions = MapToDto(questions)
            };
        }




        // ================================
        // SUBMIT QUIZ
        // ================================
        public async Task<QuizResultDto> SubmitQuizAsync(
     int attemptId,
     Dictionary<int, int> answers)
        {
            if (answers == null || answers.Count == 0)
                throw new Exception("No answers submitted");

            int totalQuestions = answers.Count;
            int correctAnswers = 0;

            var attemptAnswers = new List<QuizAttemptAnswer>();

            int? sectionId = null;
            string? sectionTitle = null;

            foreach (var entry in answers)
            {
                int questionId = entry.Key;
                int selectedOptionId = entry.Value;

                var question = await _questionRepository
                    .GetQuestionWithOptionsAsync(questionId);

                if (question == null)
                    continue;

                // Capture section info ONCE (all questions belong to same section)
                if (sectionId == null && question.SectionId != null)
                {
                    sectionId = question.SectionId;

                    if (question.Section != null)
                    {
                        sectionTitle =
                            $"{question.Section.Act.ActShortName} " +
                            $"{question.Section.SectionNumber} – {question.Section.SectionTitle}";

                    }
                }

                var selectedOption = question.Options
                    .FirstOrDefault(o => o.OptionId == selectedOptionId);

                bool isCorrect = selectedOption != null && selectedOption.IsCorrect;

                if (isCorrect)
                    correctAnswers++;

                attemptAnswers.Add(new QuizAttemptAnswer
                {
                    AttemptId = attemptId,
                    QuestionId = questionId,
                    SelectedOptionId = selectedOptionId,
                    IsCorrect = isCorrect
                });
            }

            // Save answers
            await _answerRepository.AddAnswersAsync(attemptAnswers);

            // Update attempt
            var attempt = await _attemptRepository.GetByIdAsync(attemptId);

            if (attempt == null)
                throw new Exception("Quiz attempt not found");

            attempt.CompletedOn = DateTime.UtcNow;
            attempt.TotalQuestions = totalQuestions;
            attempt.CorrectAnswers = correctAnswers;
            attempt.Score = (correctAnswers * 100) / totalQuestions;

            await _attemptRepository.UpdateAttemptAsync(attempt);

            // Return result DTO
            return new QuizResultDto
            {
                AttemptId = attempt.AttemptId,

                SectionId = sectionId,
                SectionTitle = sectionTitle,

                TotalQuestions = totalQuestions,
                CorrectAnswers = correctAnswers,
                Score = attempt.Score,
                CompletedOn = attempt.CompletedOn.Value
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
