using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MyCqrsApi.PipelineBehaviors;

var builder = WebApplication.CreateBuilder(args);

// Add controllers.
builder.Services.AddControllers();

// Explicitly scan the assembly where handlers are defined.
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

// Register all FluentValidation validators.
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

// Register the validation pipeline behavior.
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

// Add Swagger for API documentation (optional)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
