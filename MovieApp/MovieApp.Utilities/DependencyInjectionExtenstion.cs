using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.DataAccess;
using MovieApp.DataAccess.Abstraction;
using MovieApp.DataAccess.Repositories;
using MovieApp.Domain;
using MovieApp.Services.Implementation;
using MovieApp.Services.Interfaces;

namespace MovieApp.Utilities
{
    public static class DependencyInjectionExtenstion
    {

        public static IServiceCollection RegisterModule(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MovieAppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            //service registration
            services.AddTransient<IMovieService, MovieService>();

            services.AddTransient<IRepository<MovieDto>, MovieRepository>();

            return services;
        }
    }
}
