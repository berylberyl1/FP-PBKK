using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using webapi.Application.Query.Catalogue.BooksFromGenre;
using webapi.Application.Query.Catalogue.Genre;
using webapi.Domain.Catalogue.Model;
using webapi.Domain.Catalogue.Repository;
using webapi.Infrastructure.Database.EntityFramework;
using webapi.Infrastructure.Query.Catalogue;
using webapi.Infrastructure.Repository.InMemory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IBooksFromGenreQuery, BooksFromGenreQuery>();
builder.Services.AddSingleton<IGenreQuery, GenreQuery>();
builder.Services.AddSingleton<IRepository<Book>, BookRepository>();
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        options.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles();

app.Run();
