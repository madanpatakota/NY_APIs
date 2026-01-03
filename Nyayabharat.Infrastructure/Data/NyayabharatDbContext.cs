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

            modelBuilder.Entity<SituationConcept>()
                .HasKey(x => new { x.SituationId, x.ConceptId });
            modelBuilder.Entity<SituationConcept>()
                .ToTable("SituationConceptMap");

            base.OnModelCreating(modelBuilder);
        }
    }
}
