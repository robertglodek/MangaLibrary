using FluentValidation.AspNetCore;
using MangaLibrary.ApplicationServices.API.Domain.Genre;
using MangaLibrary.DataAccess.CQRS.Commands;
using MangaLibrary.DataAccess.CQRS.Queries;
using MangaLibrary.DataAccess.Data;
using MangaLibrary.DataAccess.Data.Initializer;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers().AddFluentValidation(config =>
{
    config.RegisterValidatorsFromAssembly(typeof(GetGenreRequest).Assembly);
});
builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddMediatR(typeof(GetGenreRequest).Assembly);
builder.Services.AddDbContext<MangaLibraryDbContext>(optionsBuilder =>
{
    optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("MangaLibraryConntectionString"));
});
builder.Services.AddAutoMapper(typeof(GetGenreRequest).Assembly);
builder.Services.AddScoped<IQueryExecutor, QueryExecutor>();
builder.Services.AddScoped<ICommandExecutor, CommandExecutor>();




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Configure the HTTP request pipeline.
using (var scope = app.Services.CreateScope())
{
    await scope.ServiceProvider.GetRequiredService<IDbInitializer>().InitializeAsync();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

