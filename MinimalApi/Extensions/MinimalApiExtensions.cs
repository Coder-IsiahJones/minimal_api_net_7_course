using Application.Abstractions;
using Application.Posts.Commands;
using DataAccess;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Abstractions;

namespace MinimalApi.Extensions
{
    public static class MinimalApiExtensions
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<SocialDbContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddScoped<IPostRepository, PostRepository>();

            builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(CreatePost).Assembly));
        }

        public static void RegisterEndpointDefinitions(this WebApplication app)
        { 
            var endpointDefinitions = typeof(Program).Assembly
                .GetTypes()
                .Where(t => t.IsAssignableTo(typeof(IEndpointDefinition))
                    && !t.IsAbstract && !t.IsInterface)
                .Select(Activator.CreateInstance)
                .Cast<IEndpointDefinition>();

            foreach (var endpointDefinition in endpointDefinitions)
            {
                endpointDefinition.RegisterEndpoints(app);
            }
        }
    }
}
