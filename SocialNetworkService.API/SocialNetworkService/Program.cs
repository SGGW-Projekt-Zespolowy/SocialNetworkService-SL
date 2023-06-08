using Application;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation;
using System.Reflection;
//using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Scan(selector => selector.FromAssemblies(
        Infrastructure.AssemblyReference.Assembly).AddClasses(false).AsImplementedInterfaces().WithScopedLifetime());

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

builder.Services.AddControllers().AddApplicationPart(Presentation.AssemblyReference.Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>(
    x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                        sqlServerOptionsAction: sqlOptions => { sqlOptions.EnableRetryOnFailure(); })
    );

builder.Services
    .AddApplication()
    .AddInfrastructure()
    .AddPresentation();

//builder.Host.UseSerilog((context, configuration) =>
//    configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin()
        .Build();
    });
});

//builder.Services.AddAuthorization(options =>
//{
//    options.FallbackPolicy = new AuthorizationPolicyBuilder()
//    .RequireAuthenticatedUser()
//    .Build();
//});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

//app.UseSerilogRequestLogging();

app.UseHttpsRedirection();
app.UseCors();
app.UseRouting();
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapFallbackToController("Index", "Fallback");
});

app.MapControllers();

app.Run();
