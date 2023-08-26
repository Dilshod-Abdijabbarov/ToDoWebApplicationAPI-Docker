using Microsoft.Extensions.DependencyInjection;
using ToDoWebApplication.Data.IRepositories;
using ToDoWebApplication.Data.Repositories;
using ToDoWebApplication.Services.IServices;
using ToDoWebApplication.Services.Services;

namespace ToDoWebApplication.Extensions
{
    public static class CustomExtension
    {
        public static void AddCustomExtension(this IServiceCollection services)
        {
            services.AddScoped(typeof(GenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));

            services.AddScoped<IUserRepositoryAsync, UserRepositoryAsync>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<ITaskRepositoryAsync, TaskRepositoryAsync>();
            services.AddScoped<ITaskBaseService, TaskBaseService>();

            services.AddScoped<IAddDueDateRepositoryAsync, AddDueDateRepositoryAsync>();
            services.AddScoped<IAddDueDateService, AddDueDateService>();

            services.AddScoped<IAddFileRepositoryAsync, AddFileRepositoryAsync>();
            services.AddScoped<IAddFileService, AddFileService>();

            services.AddScoped<ICategoryRepositoryAsync, CategoryRepositoryAsync>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IRepeatTimeRepositoryAsync, RepeatTimeRepositoryAsync>();
            services.AddScoped<IRepeatTimeService, RepeatTimeService>();
        }
    }
}
