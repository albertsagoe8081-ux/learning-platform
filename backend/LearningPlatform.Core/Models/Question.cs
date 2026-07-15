namespace LearningPlatform.Core.Models
{
    public enum QuestionType
    {
        MultipleChoice,
        TrueFalse,
        ShortAnswer,
        Essay
    }

    public class Question
    {
        public int Id { get; set; }
        public int QuizId { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public QuestionType Type { get; set; }
        public int Points { get; set; } = 1;
        public int Order { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public Quiz? Quiz { get; set; }
        public ICollection<Answer>? Answers { get; set; }
    }
}