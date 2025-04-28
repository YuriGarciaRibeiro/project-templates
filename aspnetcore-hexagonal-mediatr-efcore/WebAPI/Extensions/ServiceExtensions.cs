using Application.Behaviors;
using Application.UserCases.CreateUser;
using Core.Interfaces;
using FluentValidation;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace WebAPI.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        // ADD YOUR SERVICES HERE
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        // ADD YOUR REPOSITORIES HERE
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        // ADD YOUR DATABASE CONTEXT HERE
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }

    public static IServiceCollection AddMediatR(this IServiceCollection services)
    {   
        // ADD YOUR MEDIATR HANDLERS HERE
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateUserCommand).Assembly));
        services.AddValidatorsFromAssemblyContaining<CreateUserCommandHandlerValidator>();
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }

    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        // ADD YOUR SWAGGER HERE
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new() { Title = "My API", Version = "v1" });
        });

        return services;
    }

    public static IServiceCollection AddCors(this IServiceCollection services)
    {
        // ADD YOUR CORS HERE
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins",
                builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });

        return services;
    }

    public static IServiceCollection AddProjectServices(this IServiceCollection services,IConfiguration configuration)
    {
        // ADD YOUR PROJECT SERVICES HERE
        services.AddCors();
        services.AddSwagger();
        services.AddMediatR();
        services.AddServices();
        services.AddRepositories();
        services.AddDatabase(configuration);

        return services;
    }

}
