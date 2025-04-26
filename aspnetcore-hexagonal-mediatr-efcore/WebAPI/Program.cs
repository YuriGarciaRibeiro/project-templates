using Application.Behaviors;
using Core.Interfaces;
using Infrastructure.Persistence;
using MediatR;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Application.UserCases.CreateUser;
using WebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("FakeDb"));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateUserCommand).Assembly));

builder.Services.AddValidatorsFromAssemblyContaining<CreateUserCommandHandlerValidator>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure middleware
app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ExceptionHandlingMiddleware>();


app.MapControllers();
app.Run();
