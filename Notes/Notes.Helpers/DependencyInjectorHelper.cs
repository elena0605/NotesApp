using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Notes.DataAccess;
using Notes.DataAccess.Interfaces;
using Notes.DataAccess.Repositories;
using Notes.Domain.Models;
using Notes.Services.Abstraction;
using Notes.Services.Implementation;

namespace Notes.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void InjectDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<NotesDbContext>(options =>
                options.UseSqlServer(connectionString));
        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
           
            services.AddTransient<IRepository<Note>, NoteRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<INoteService, NoteService>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}
