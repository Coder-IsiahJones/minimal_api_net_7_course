using Application.Abstractions;
using DataAccess;
using DataAccess.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SocialDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IPostRepository, PostRepository>();

builder.Services.AddMediatR(typeof(Program));

var app = builder.Build();

app.UseHttpsRedirection();

app.Run();