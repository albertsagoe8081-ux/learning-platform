namespace LearningPlatform.Core.Models
{
    public class QuizAttempt
    {
        public int Id { get; set; }
        public int StudentUserId { get; set; }
        public int QuizId { get; set; }
        public int Score { get; set; }
        public int MaxScore { get; set; }
        public decimal PercentageScore { get; set; }
        public bool Passed { get; set; }
        public DateTime StartedAt { get; set; } = DateTime.UtcNow;
        public DateTime? CompletedAt { get; set; }
        public int TimeTakenSeconds { get; set; } = 0;

        public User? StudentUser { get; set; }
        public Quiz? Quiz { get; set; }
        public ICollection<StudentAnswer>? StudentAnswers { get; set; }
    }
}