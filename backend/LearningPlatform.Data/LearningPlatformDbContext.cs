using Microsoft.EntityFrameworkCore;
using LearningPlatform.Core.Models;

namespace LearningPlatform.Data
{
    public class LearningPlatformDbContext : DbContext
    {
        public LearningPlatformDbContext(DbContextOptions<LearningPlatformDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Content> Contents { get; set; } = null!;
        public DbSet<Quiz> Quizzes { get; set; } = null!;
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<Answer> Answers { get; set; } = null!;
        public DbSet<QuizAttempt> QuizAttempts { get; set; } = null!;
        public DbSet<StudentAnswer> StudentAnswers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.PasswordHash).IsRequired();
                entity.HasIndex(e => e.Email).IsUnique();
            });

            modelBuilder.Entity<Content>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(255);
                entity.HasOne(e => e.CreatedByUser)
                    .WithMany(u => u.CreatedContent)
                    .HasForeignKey(e => e.CreatedByUserId);
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(255);
                entity.HasOne(e => e.CreatedByUser)
                    .WithMany(u => u.CreatedQuizzes)
                    .HasForeignKey(e => e.CreatedByUserId);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.QuestionText).IsRequired();
                entity.HasOne(e => e.Quiz)
                    .WithMany(q => q.Questions)
                    .HasForeignKey(e => e.QuizId);
            });

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.AnswerText).IsRequired();
                entity.HasOne(e => e.Question)
                    .WithMany(q => q.Answers)
                    .HasForeignKey(e => e.QuestionId);
            });

            modelBuilder.Entity<QuizAttempt>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.StudentUser)
                    .WithMany(u => u.QuizAttempts)
                    .HasForeignKey(e => e.StudentUserId);
                entity.HasOne(e => e.Quiz)
                    .WithMany(q => q.Attempts)
                    .HasForeignKey(e => e.QuizId);
            });

            modelBuilder.Entity<StudentAnswer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.QuizAttempt)
                    .WithMany(qa => qa.StudentAnswers)
                    .HasForeignKey(e => e.QuizAttemptId);
                entity.HasOne(e => e.Question)
                    .WithMany()
                    .HasForeignKey(e => e.QuestionId);
            });
        }
    }
}