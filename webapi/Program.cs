using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using webapi.Application.Query.Catalogue.RandomBooksFromGenre;
using webapi.Application.Query.Catalogue.Genre;
using webapi.Domain.Catalogue.Repository;
using webapi.Infrastructure.Database.EntityFramework;
using webapi.Infrastructure.Query.Catalogue;
using webapi.Infrastructure.Repository.SQLServer;
using webapi.Domain.Account.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using webapi.Application.Query.Catalogue.BookDetail;
using webapi.Application.Query.Catalogue.BookRecommendation;
using webapi.Domain.Payment.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer((options) => {
        options.TokenValidationParameters = new TokenValidationParameters {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                builder.Configuration["Jwt:Key"] ?? ""))
        };
    });

builder.Services.AddTransient<IRandomBooksFromGenreQuery, RandomBooksFromGenreQuery>();
builder.Services.AddTransient<IGenreQuery, GenreQuery>();
builder.Services.AddTransient<IBookDetailQuery, BookDetailQuery>();
builder.Services.AddTransient<IBookRecommendationQuery, BookRecommendationQuery>();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles();

app.Run();
