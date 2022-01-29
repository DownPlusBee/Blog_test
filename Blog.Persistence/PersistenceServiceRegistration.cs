using Blog.Application.Interfaces.Persistance;
using Blog.Persistence.Helpers;
using Blog.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Blog.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BlogContext>(options => options.UseSqlite($"Data Source={GetDatabasePath()}"));

            services.AddScoped(typeof(Application.Interfaces.Persistance.ISortHelper<>), typeof(SortHelper<>));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IBlogPostRepository, BlogPostRepository>();

            return services;
        }

        private static string GetDatabasePath()
        {
            Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
            string path = Environment.GetFolderPath(folder);
            string dbPath = System.IO.Path.Join(path, "Blogging.db");

            return dbPath;
        }
    }
}
