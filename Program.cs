using Abattage_BackEnd.Data;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.ApiKey,
        In = ParameterLocation.Header,
        Name = "Authorization",
    });
    opt.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddDbContext<UserDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("UserDbString"))
);


builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("AppDbString"))
);


builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<UserDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapIdentityApi<IdentityUser>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var roles = new[] { "Admin", "Veterinaire", "Boucher", "Eleveur", "Transporteur", "Abatteur", "Vendeur", "Acheteur" };

    foreach (var role in roles)
    {
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var usermanager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
        if (await roleManager.RoleExistsAsync(role))
        {
            await roleManager.DeleteAsync(await roleManager.FindByNameAsync(role));
        }

        await roleManager.CreateAsync(new IdentityRole(role));
        string email = role.ToLower() + "@gmail.com";
        string password = "P@ssw0rd";

        if (await usermanager.FindByEmailAsync(email) == null)
        {
            var user = new IdentityUser
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true
            };
            await usermanager.CreateAsync(user, password);
            await usermanager.AddToRoleAsync(user, role);
        }

    }
}


app.Run();
