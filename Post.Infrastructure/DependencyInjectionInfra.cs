using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Post.Domain.Repository;
using Post.Infrastructure.Data;
using Post.Infrastructure.Repository;


namespace Post.Infrastructure
{
    public static  class DependencyInjectionInfra
    {
        public static IServiceCollection AddInfrastructureLayerService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AuthorDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("AuthorDbContext")??
                   throw new InvalidOperationException("connection string not found")) // ?? => if  null
            );
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            return services;
        }
    }
}
