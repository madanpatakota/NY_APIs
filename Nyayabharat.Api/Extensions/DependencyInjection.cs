using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nyayabharat.Application.Interfaces.Repositories;
using Nyayabharat.Application.Interfaces.Services;
using Nyayabharat.Application.Services;
using Nyayabharat.Infrastructure.Data;
using Nyayabharat.Infrastructure.Repositories;

namespace Nyayabharat.Api.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<NyayabharatDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IActRepository, ActRepository>();
            services.AddScoped<ISectionRepository, SectionRepository>();
            services.AddScoped<ISituationRepository, SituationRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IQuizService, QuizService>();
            services.AddScoped<ISituationService, SituationService>();

            services.AddScoped<IActService, ActService>();
            services.AddScoped<ISectionService, SectionService>();
            services.AddScoped<IConceptRepository, ConceptRepository>();
            services.AddScoped<ISituationLawService, SituationLawService>();

            services.AddScoped<IQuizAttemptRepository, QuizAttemptRepository>();
            services.AddScoped<IQuizAttemptAnswerRepository, QuizAttemptAnswerRepository>();
            services.AddScoped<IUserProgressRepository, UserProgressRepository>();

            services.AddScoped<ITranslationRepository, TranslationRepository>();
            services.AddScoped<ITranslationService, TranslationService>();

                            services.AddScoped<IChapterRepository, ChapterRepository>();
            services.AddScoped<IChapterService, ChapterService>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<ISituationGuidanceRepository, SituationGuidanceRepository>();


            return services;
        }
    }
}
