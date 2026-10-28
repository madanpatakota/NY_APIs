namespace Nyayabharat.Application.Helpers
{
    public sealed class QuizScoreCalculator
    {
        public int CalculateScore(int correctAnswers, int totalQuestions)
        {
            return (correctAnswers * 100) / totalQuestions;
        }
    }
}
