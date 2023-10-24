

using ManageStudents.API.Abstraction;
using ManageStudents.API.Application.Authorization;
using ManageStudents.API.Application.Services;
using ManageStudents.Infrastructure.Abstractions;
using ManageStudents.Infrastructure.Repositories.UsersRepository;

namespace ManageStudents.API.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IGiangVienService, GiangVienService>();
        services.AddScoped<ISinhVienService, SinhVienService>();
        //services.AddScoped<ISubmissionService, SubmissionService>();
        //services.AddScoped<IStringResourceService, StringResourceService>();

        //services.AddScoped<ITemplateRepository, TemplateRepository>();
        //services.AddScoped<IQuestionRepository, QuestionRepository>();
        //services.AddScoped<IAnswerRepository, AnswerRepository>();
        //services.AddScoped<ISubmissionRepository, SubmissionRepository>();
        services.AddScoped<IDiaChiRepository, DiaChiRepository>();
        services.AddScoped<IGiangVienRepository, GiangVienRepository>();
        services.AddScoped<IKhoaRepository, KhoaRepository>();
        services.AddScoped<ILopSinhVienRepository, LopSinhVienRepository>();
        services.AddScoped<ISinhVienRepository, SinhVienRepository>();
        services.AddScoped<ITruongRepository, TruongRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<HttpClientAuthorizationDelegatingHandler>();

        return services;
    }
}