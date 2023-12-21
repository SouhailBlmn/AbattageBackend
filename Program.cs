using Abattage_BackEnd.Data;
using Abattage_BackEnd.Models;
using Abattage_BackEnd.UnitOfWork;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Enable cors for all origins, headers and methods
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.WithOrigins("https://localhost:4200").AllowCredentials().WithMethods(["GET", "POST", "PUT", "DELETE"]).AllowAnyHeader();
    });
});



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

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<UserDbContext>();

// builder.Services.ConfigureApplicationCookie(options =>
// {
//     options.Cookie.SameSite = SameSiteMode.None;
//     options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
//     options.Cookie.HttpOnly = true;
// });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.MapIdentityApi<IdentityUser>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// using (var scope = app.Services.CreateScope())
// {
//     var roles = new[] { "Admin", "Veterinaire", "Boucher", "Eleveur", "Transporteur", "Abatteur", "Vendeur", "Acheteur" };

//     foreach (var role in roles)
//     {
//         var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
//         var usermanager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
//         if (await roleManager.RoleExistsAsync(role))
//         {
//             await roleManager.DeleteAsync(await roleManager.FindByNameAsync(role));
//         }

//         await roleManager.CreateAsync(new IdentityRole(role));
//         string email = role.ToLower() + "@gmail.com";
//         string password = "P@ssw0rd";

//         if (await usermanager.FindByEmailAsync(email) == null)
//         {
//             var user = new IdentityUser
//             {
//                 UserName = email,
//                 Email = email,
//                 EmailConfirmed = true
//             };
//             await usermanager.CreateAsync(user, password);
//             await usermanager.AddToRoleAsync(user, role);
//         }

//     }

// //Seed data into chevillard table
// var chevillard = scope.ServiceProvider.GetRequiredService<IUnitOfWork>().Chevillards;
// Client acheteurIntestin = new Client
// {
//     Nom = "Acheteur Intestin",
//     Plafond = 0
// };
// Client acheteurPeau = new Client
// {
//     Nom = "Acheteur Peau",
//     Plafond = 0
// };
// Client acheteurTete = new Client
// {
//     Nom = "Acheteur Tete",
//     Plafond = 0
// };
// Client acheteurAutre = new Client
// {
//     Nom = "Acheteur Autre",
//     Plafond = 0
// };

// var clients = scope.ServiceProvider.GetRequiredService<IUnitOfWork>().Clients;
// await clients.AddAsync(acheteurIntestin);
// await clients.AddAsync(acheteurPeau);
// await clients.AddAsync(acheteurTete);
// await clients.AddAsync(acheteurAutre);


// Chevillard chevillard1 = new Chevillard
// {
//     Nom = "Chevillard 1",
//     Plafond = 0,
//     Cin = "CIN 1",
//     CinImg = "CIN 1",
//     AcheteurIntestin = acheteurIntestin,
//     AcheteurPeau = acheteurPeau,
//     AcheteurTete = acheteurTete,
//     AcheteurAutre = acheteurAutre,
//     Num_carte = "Num carte 1",
//     Infos = "Infos 1",
//     Telephone = "Telephone 1",
//     Actif = true
// };
// await chevillard.AddAsync(chevillard1);

// Stabulation stabulationVaches = new Stabulation
// {
//     Id = 1,
//     Capacite = 1000,
//     Designation = "Stabulation vacche",
//     EstPlein = false,
//     Libre = 1000,
//     Utilisee = 0
// };
// Stabulation stabulationMoutons = new Stabulation
// {
//     Id = 2,
//     Capacite = 1000,
//     Designation = "Stabulation moutons",
//     EstPlein = false,
//     Libre = 1000,
//     Utilisee = 0
// };
// Stabulation stabulationBovins = new Stabulation
// {
//     Id = 3,
//     Capacite = 1000,
//     Designation = "Stabulation bovins",
//     EstPlein = false,
//     Libre = 1000,
//     Utilisee = 0
// };
// var stabulations = scope.ServiceProvider.GetRequiredService<IUnitOfWork>().Stabulations;
// await stabulations.AddAsync(stabulationVaches);
// await stabulations.AddAsync(stabulationMoutons);
// await stabulations.AddAsync(stabulationBovins);


// //Seed data into reception table
// Reception reception1 = new Reception
// {
//     Chevillard = chevillard1,
//     Tripier = 1,
//     Nombre = 1,
//     StabulationVaches = stabulationVaches,
//     StabulationMoutons = stabulationMoutons,
//     StabulationBovins = stabulationBovins,
//     NbBovins = 1,
//     NbVaches = 1,
//     NbMoutons = 1,
//     AcheteurIntestin = acheteurIntestin,
//     AcheteurPeau = acheteurPeau,
//     AcheteurTete = acheteurTete,
//     AcheteurAutre = acheteurAutre
// };
// var receptions = scope.ServiceProvider.GetRequiredService<IUnitOfWork>().Receptions;
// await receptions.AddAsync(reception1);

// };


app.Run();
