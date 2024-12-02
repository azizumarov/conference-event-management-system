using CEMS.AuthService.Models;
using CEMS.Core.Configurations;
using CEMS.Core.Entities;
using CEMS.Core.Interfaces;
using CEMS.Core.RepositoryInterfaces.DalRepositories;
using CEMS.Dal;
using CEMS.Dal.Configuration;
using CEMS.Dal.Models;
using CEMS.Dal.Repositories;
using CEMS.Dal.SqlContext;
using CEMS.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace CEMS.AuthService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateSlimBuilder(args);
            var configuration = builder.Configuration;

            
            builder.Services.ConfigureDal(configuration);

            builder.Services.AddScoped<IAuthService, AuthService>();

            builder.Services.ConfigureHttpJsonOptions(options =>
            {
                options.SerializerOptions.TypeInfoResolver = AppJsonSerializerContext.Default;
            });

            var app = builder.Build();
            
            app.MapPost("/register", async ([FromBody] AddUserModel model, IAuthService authService) =>
            {
                var user = new Core.Entities.User
                {
                    Id = Guid.NewGuid(),
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Login = model.Login,
                    PasswordHash = model.Password
                };

                var success = await authService.RegisterUserAsync(user);
                if (!success)
                {
                    return Results.BadRequest("User already exists.");
                }

                return Results.Ok("User registered successfully.");
            });

            app.MapPost("/login", async ([FromBody] LoginUserModel model, IAuthService authService) =>
            {
                var result = await authService.AuthenticateUserAsync(model.Login, model.Password);
                if (result == null)
                {
                    return Results.Unauthorized();
                }

                return Results.Ok(new
                {
                    Message = "Login successful",
                    Login = model.Login
                });
            });

            app.MapPost("/assign-role", async (Guid userId, Guid roleId, IAuthService authService) =>
            {
                var success = await authService.AssignRoleToUserAsync(userId, roleId);
                if (!success)
                {
                    return Results.BadRequest("Failed to assign role. Either user or role does not exist.");
                }

                return Results.Ok("Role assigned successfully.");
            });

            app.MapGet("/roles/{userId:guid}", async (Guid userId, IAuthService authService) =>
            {
                var roles = await authService.GetUserRolesAsync(userId);
                return Results.Ok(roles);
            });

            app.Run();
        }
    }

    
    [JsonSerializable(typeof(AddUserModel))]
    [JsonSerializable(typeof(ViewUserModel))]
    [JsonSerializable(typeof(LoginUserModel))] 
    internal partial class AppJsonSerializerContext : JsonSerializerContext
    {

    }
}
