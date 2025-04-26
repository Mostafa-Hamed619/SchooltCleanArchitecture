using Microsoft.EntityFrameworkCore;
using School.Core;
using School.Core.Middlewares;
using School.Infra;
using School.Infra.Context;
using School.Service;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbContext"));
});

builder.Services.AddInfrastructureDependencies()
                .AddServiceDependencies()
                .AddCoreDependencies();

builder.Services.AddOpenApi();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(opt => opt.SwaggerEndpoint("/openAPI/v1.json", "v1"));
}
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
