using WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.AddSwagger()
       .AddDatabase(builder.Configuration)
       .AddMediatR()
       .AddRepositories()
       .AddServices();

builder.Services.AddControllers();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseMiddlewares();

app.MapControllers();
app.UserMetrics();

app.Run();
