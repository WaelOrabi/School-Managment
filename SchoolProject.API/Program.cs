using Microsoft.EntityFrameworkCore;
using SchoolProject.Core;
using SchoolProject.Core.Middleware;
using SchoolProject.infrastructure;
using SchoolProject.infrastructure.Data;
using SchoolProject.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configure DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("constr"));
});

#region Dependency Injections
builder.Services.AddInfrastructureDependencies().AddServiceDependencies().AddCoreDependencies();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "School API V1");
        c.RoutePrefix = string.Empty;
    });
}
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
