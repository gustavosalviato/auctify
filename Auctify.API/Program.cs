using Auctify.API.Contracts;
using Auctify.API.Entities;
using Auctify.API.Filters;
using Auctify.API.Infra;
using Auctify.API.Infra.Repositories;
using Auctify.API.UseCases.Users.Create;
using Auctify.API.UseCases.Users.Update;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

builder.Services.AddMvc(option => option.Filters.Add(typeof(ExceptionFilter)));

builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<CreateUserUseCase>();
builder.Services.AddScoped<UpdateUserUseCase>();

builder.Services.AddScoped<IUserRepository, UsersRepository>();

builder.Services.AddDbContext<AuctifyDbContext>(option =>
{
    option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});


var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();