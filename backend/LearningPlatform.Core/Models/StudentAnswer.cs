namespace LearningPlatform.Core.Models
{
    public class StudentAnswer
    {
        public int Id { get; set; }
        public int QuizAttemptId { get; set; }
        public int QuestionId { get; set; }
        public string StudentAnswerText { get; set; } = string.Empty;
        public int? SelectedAnswerId { get; set; }
        public bool IsCorrect { get; set; }
        public int PointsScored { get; set; }
        public DateTime AnsweredAt { get; set; } = DateTime.UtcNow;

        public QuizAttempt? QuizAttempt { get; set; }
        public Question? Question { get; set; }
    }
}