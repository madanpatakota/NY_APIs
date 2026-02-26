using Microsoft.EntityFrameworkCore;
using Nyayabharat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Nyayabharat.Infrastructure.Data
{
    public class NyayabharatDbContext : DbContext
    {
        public NyayabharatDbContext(DbContextOptions<NyayabharatDbContext> options)
            : base(options)
        {
        }

        public DbSet<Act> Acts => Set<Act>();
        public DbSet<Chapter> Chapters => Set<Chapter>();
        public DbSet<Section> Sections => Set<Section>();
        public DbSet<SubSection> SubSections => Set<SubSection>();
        public DbSet<Clause> Clauses => Set<Clause>();

        public DbSet<Amendment> Amendments => Set<Amendment>();
        public DbSet<SectionAmendment> SectionAmendments => Set<SectionAmendment>();

        public DbSet<Concept> Concepts => Set<Concept>();
        public DbSet<ConceptSection> ConceptSections => Set<ConceptSection>();

        public DbSet<Situation> Situations => Set<Situation>();
        public DbSet<SituationSection> SituationSections => Set<SituationSection>();
        public DbSet<SituationConcept> SituationConcepts => Set<SituationConcept>();

        public DbSet<Question> Questions => Set<Question>();
        public DbSet<Option> Options => Set<Option>();
        public DbSet<Explanation> Explanations => Set<Explanation>();

        public DbSet<User> Users => Set<User>();
        public DbSet<QuizAttempt> QuizAttempts => Set<QuizAttempt>();
        public DbSet<QuizAttemptQuestion> QuizAttemptQuestions => Set<QuizAttemptQuestion>();
        public DbSet<QuizAttemptAnswer> QuizAttemptAnswers => Set<QuizAttemptAnswer>();
        public DbSet<UserProgress> UserProgresses => Set<UserProgress>();

        public DbSet<Language> Languages => Set<Language>();
        public DbSet<Translation> Translations => Set<Translation>();
        //public DbSet<SituationSection> SituationSections { get; set; }
        //public DbSet<SituationConcept> SituationConcepts { get; set; }
        //public DbSet<QuizAttempt> QuizAttempts { get; set; }
        //public DbSet<QuizAttemptQuestion> QuizAttemptQuestions { get; set; }
        //public DbSet<QuizAttemptAnswer> QuizAttemptAnswers { get; set; }
        // public DbSet<UserProgress> UserProgress { get; set; }

        //public DbSet<Language> Languages { get; set; }
        //public DbSet<Translation> Translations { get; set; }

        public DbSet<SituationGuidance> SituationGuidance { get; set; }


        public DbSet<SectionParallel> SectionParallelMap { get; set; } = null!;

        public DbSet<ActCategory> ActCategories { get; set; }
        //public DbSet<Act> Acts { get; set; }

        //public DbSet<Section> Sections { get; set; }
        public DbSet<SectionContent> SectionContents { get; set; }
        //public DbSet<SectionAmendment> SectionAmendments { get; set; }
        //public DbSet<Chapter> Chapters { get; set; }
        //public DbSet<Act> Acts { get; set; }

        // 🔽 ADD THESE
        public DbSet<Judgment> Judgments { get; set; }
        public DbSet<AppealRight> AppealRights { get; set; }
        public DbSet<UserBookmark> UserBookmarks { get; set; }
        public DbSet<SectionJudgmentMap> SectionJudgmentMaps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SectionAmendment>()
                .HasKey(x => new { x.SectionId, x.AmendmentId });
            modelBuilder.Entity<SectionAmendment>()
                .ToTable("SectionAmendmentMap");

            modelBuilder.Entity<ConceptSection>()
                .HasKey(x => new { x.ConceptId, x.SectionId });
            modelBuilder.Entity<ConceptSection>()
                .ToTable("ConceptSectionMap");



            modelBuilder.Entity<SituationSection>()
    .HasKey(x => new { x.SituationId, x.SectionId });

            modelBuilder.Entity<SituationSection>()
                .ToTable("SituationSectionMap");

            modelBuilder.Entity<SituationSection>()
                .HasOne(ss => ss.Section)
                .WithMany(s => s.SituationSections)
                .HasForeignKey(ss => ss.SectionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SituationSection>()
                .HasOne(ss => ss.Situation)
                .WithMany(s => s.SituationSections)
                .HasForeignKey(ss => ss.SituationId)
                .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<SituationSection>()
            //    .HasKey(x => new { x.SituationId, x.SectionId });
            //modelBuilder.Entity<SituationSection>()
            //    .ToTable("SituationSectionMap");

            modelBuilder.Entity<SituationConcept>()
                .HasKey(x => new { x.SituationId, x.ConceptId });
            modelBuilder.Entity<SituationConcept>()
                .ToTable("SituationConceptMap");

            modelBuilder.Entity<SectionParallel>()
    .Property(x => x.NewSectionNumber)
    .IsRequired(false);


            modelBuilder.Entity<Question>()
       .Property(q => q.QuestionType)
       .HasConversion<string>();

            modelBuilder.Entity<ActCategory>()
       .ToTable("ActCategories");

            modelBuilder.Entity<Act>()
                .HasOne(a => a.ActCategory)
                .WithMany(c => c.Acts)
                .HasForeignKey(a => a.ActCategoryId);

            modelBuilder.Entity<Translation>(entity =>
            {
                entity.ToTable("Translations");

                entity.Property(e => e.TranslatedText)
                      .HasColumnName("TranslatedText");

                entity.Property(e => e.FieldName)
                      .HasColumnName("FieldName");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("Languages");

                entity.Property(l => l.IsActive)
                      .HasColumnName("IsActive");
            });

            modelBuilder.Entity<SectionJudgmentMap>()
       .HasKey(x => new { x.SectionId, x.JudgmentId });

            modelBuilder.Entity<SectionJudgmentMap>()
                .HasOne(x => x.Judgment)
                .WithMany()
                .HasForeignKey(x => x.JudgmentId);


            // Section ↔ Judgment (already added)
            modelBuilder.Entity<SectionJudgmentMap>()
                .HasKey(x => new { x.SectionId, x.JudgmentId });

            modelBuilder.Entity<SectionJudgmentMap>()
                .HasOne(x => x.Judgment)
                .WithMany()
                .HasForeignKey(x => x.JudgmentId);

            // 🔽 ADD THIS FOR UserBookmark
            modelBuilder.Entity<UserBookmark>()
                .HasKey(x => new { x.UserId, x.SectionId });

            modelBuilder.Entity<SectionJudgmentMap>()
    .ToTable("SectionJudgmentMap");

//            modelBuilder.Entity<Section>()
//.HasOne(s => s.Explanation)
//.WithOne()
//.HasForeignKey<Explanation>(e => e.SectionId);

            modelBuilder.Entity<Section>()
       .HasOne(s => s.Explanation)
       .WithOne(e => e.Section)
       .HasForeignKey<Explanation>(e => e.SectionId)
       .OnDelete(DeleteBehavior.Cascade);


            base.OnModelCreating(modelBuilder);


        }
    }
}
