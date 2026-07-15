namespace LearningPlatform.Core.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string AnswerText { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }
        public int Order { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Question? Question { get; set; }
    }
}