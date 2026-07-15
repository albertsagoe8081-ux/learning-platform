namespace LearningPlatform.Core.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CreatedByUserId { get; set; }
        public string Subject { get; set; } = string.Empty;
        public int TotalQuestions { get; set; }
        public int PassingScore { get; set; } = 50;
        public int TimeLimit { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;

        public User? CreatedByUser { get; set; }
        public ICollection<Question>? Questions { get; set; }
        public ICollection<QuizAttempt>? Attempts { get; set; }
    }
}