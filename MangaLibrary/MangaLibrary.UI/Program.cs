using FluentValidation.AspNetCore;
using MangaLibrary.ApplicationServices.API.Domain.Genre;
using MangaLibrary.DataAccess.CQRS.Commands;
using MangaLibrary.DataAccess.CQRS.Queries;
using MangaLibrary.DataAccess.Data;
using MangaLibrary.DataAccess.Data.Initializer;
using MangaLibrary.UI.Middleware;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog.Web;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
builder.Logging.AddConsole();
builder.Host.UseNLog();
builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddMediatR(typeof(GetGenreByIdRequest).Assembly);
builder.Services.AddAutoMapper(typeof(GetGenreByIdRequest).Assembly);
builder.Services.AddScoped<IQueryExecutor, QueryExecutor>();
builder.Services.AddScoped<ICommandExecutor, CommandExecutor>();
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddScoped<RequestTimeMiddleware>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MangaLibraryDbContext>(optionsBuilder =>
{
    optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("MangaLibraryConntectionString"));
});
builder.Services.AddControllers().AddFluentValidation(config =>
{
    config.RegisterValidatorsFromAssembly(typeof(GetGenreByIdRequest).Assembly);
});
builder.Services.Configure<ApiBehaviorOptions>(options => 
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddCors(options =>
{
    var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<IEnumerable<string>>().ToArray();
    options.AddPolicy("FrontEndClients", builder =>
                 builder.AllowAnyMethod().AllowAnyHeader().WithOrigins(allowedOrigins));
});



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    await scope.ServiceProvider.GetRequiredService<IDbInitializer>().InitializeAsync();
}

// Configure the HTTP request pipeline.
app.UseExceptionHandlerMiddleware();
app.UseRequestTimeHandlerMiddleware();
app.UseCors("FrontEndClients");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(configure => 
{
    configure.MapControllers();
});
app.Run();





