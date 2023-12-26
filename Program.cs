using Abattage_BackEnd;
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
        builder.SetIsOriginAllowed(origin => IsOriginAllowed(origin)).AllowCredentials().WithMethods(["GET", "POST", "PUT", "DELETE"]).AllowAnyHeader();
    });
});

bool IsOriginAllowed(string origin)
{
    return true;
}



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
    opt.UseNpgsql(builder.Configuration.GetConnectionString("AppDbString")).EnableSensitiveDataLogging()
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


// //SEED START



// using (var serviceScope = app.Services.CreateScope())
// {
//     var context = serviceScope.ServiceProvider.GetService<AppDbContext>(); // Replace MyDbContext with your DbContext class
//     context.Database.EnsureDeleted();
//     context.Database.EnsureCreated();


//     //Seeding data for all my models
//     //Seed data into typeBetail table


//     //Animal statuses
//     AnimalStatus animalStatus1 = new AnimalStatus
//     {
//         Id = 1,
//         Designation = "Recu"
//     };
//     AnimalStatus animalStatus2 = new AnimalStatus
//     {
//         Id = 2,
//         Designation = "En attante de pointage"
//     };

//     AnimalStatus animalStatus3 = new AnimalStatus
//     {
//         Id = 3,
//         Designation = "Poitu"
//     };

//     AnimalStatus animalStatus4 = new AnimalStatus
//     {
//         Id = 4,
//         Designation = "Planifie"
//     };

//     AnimalStatus animalStatus5 = new AnimalStatus
//     {
//         Id = 5,
//         Designation = "Abattu"
//     };


//     //Saving animal statuses
//     var animalStatuses = serviceScope.ServiceProvider.GetRequiredService<IUnitOfWork>().AnimalStatuses;
//     await animalStatuses.AddAsync(animalStatus1);
//     await animalStatuses.AddAsync(animalStatus2);
//     await animalStatuses.AddAsync(animalStatus3);
//     await animalStatuses.AddAsync(animalStatus4);
//     await animalStatuses.AddAsync(animalStatus5);



//     //Article statuses
//     ArticleStatus articleStatus1 = new ArticleStatus
//     {
//         Id = 1,
//         Libelle = "Validee"
//     };

//     ArticleStatus articleStatus2 = new ArticleStatus
//     {
//         Id = 2,
//         Libelle = "En attente de validation"
//     };

//     ArticleStatus articleStatus3 = new ArticleStatus
//     {
//         Id = 3,
//         Libelle = "Probeleme de foie"
//     };

//     ArticleStatus articleStatus4 = new ArticleStatus
//     {
//         Id = 4,
//         Libelle = "Probleme de peau"
//     };

//     ArticleStatus articleStatus5 = new ArticleStatus
//     {
//         Id = 5,
//         Libelle = "Probleme de tete"
//     };

//     ArticleStatus articleStatus6 = new ArticleStatus
//     {
//         Id = 6,
//         Libelle = "Probleme de intestin"
//     };



//     //Save article statuses
//     var articleStatuses = serviceScope.ServiceProvider.GetRequiredService<IUnitOfWork>().ArticleStatuses;
//     await articleStatuses.AddAsync(articleStatus1);
//     await articleStatuses.AddAsync(articleStatus2);
//     await articleStatuses.AddAsync(articleStatus3);
//     await articleStatuses.AddAsync(articleStatus4);
//     await articleStatuses.AddAsync(articleStatus5);
//     await articleStatuses.AddAsync(articleStatus6);



//     //Cliens
//     Client client1 = new Client
//     {
//         Id = 1,
//         Nom = "Client 1",
//         Plafond = 0
//     };

//     Client client2 = new Client
//     {
//         Id = 2,
//         Nom = "Client 2",
//         Plafond = 0
//     };

//     Client client3 = new Client
//     {
//         Id = 3,
//         Nom = "Client 3",
//         Plafond = 0
//     };


//     //Save clients

//     var clients = serviceScope.ServiceProvider.GetRequiredService<IUnitOfWork>().Clients;
//     await clients.AddAsync(client1);
//     await clients.AddAsync(client2);
//     await clients.AddAsync(client3);



//     //Stabulations

//     Stabulation stabulation1 = new Stabulation
//     {
//         Id = 1,
//         Designation = "Stabulation 1",
//         Capacite = 1000,
//         Libre = 1000,
//         Utilisee = 0,
//         EstPlein = false
//     };


//     Stabulation stabulation2 = new Stabulation
//     {
//         Id = 2,
//         Designation = "Stabulation 2",
//         Capacite = 1000,
//         Libre = 1000,
//         Utilisee = 0,
//         EstPlein = false
//     };


//     Stabulation stabulation3 = new Stabulation
//     {
//         Id = 3,
//         Designation = "Stabulation 3",
//         Capacite = 1000,
//         Libre = 1000,
//         Utilisee = 0,
//         EstPlein = false
//     };


//     //Save stabulations
//     var stabulations = serviceScope.ServiceProvider.GetRequiredService<IUnitOfWork>().Stabulations;
//     await stabulations.AddAsync(stabulation1);
//     await stabulations.AddAsync(stabulation2);
//     await stabulations.AddAsync(stabulation3);



//     //Type abattage


//     TypeAbattage typeAbattage1 = new TypeAbattage
//     {
//         Id = 1,
//         Designation = "Abattage 1"
//     };

//     TypeAbattage typeAbattage2 = new TypeAbattage
//     {
//         Id = 2,
//         Designation = "Abattage 2"
//     };

//     TypeAbattage typeAbattage3 = new TypeAbattage
//     {
//         Id = 3,
//         Designation = "Abattage 3"
//     };


//     //Save type abattage

//     var typeAbattages = serviceScope.ServiceProvider.GetRequiredService<IUnitOfWork>().TypeAbattages;

//     await typeAbattages.AddAsync(typeAbattage1);
//     await typeAbattages.AddAsync(typeAbattage2);
//     await typeAbattages.AddAsync(typeAbattage3);

//     // Add ArticleBetail entities
//     var articles = new[]
//     {
//             new ArticleBetail { Designation = "Peau" },
//             new ArticleBetail { Designation = "Tete" },
//             // ... other ArticleBetail instances ...
//         };

//     foreach (var article in articles)
//     {
//         if (!context.ArticlesBetails.Any(a => a.Designation == article.Designation))
//         {
//             await context.ArticlesBetails.AddAsync(article);
//         }
//     }

//     // Add TypeBetail entities
//     var types = new[]
//     {
//             new TypeBetail { Designation = "Vache" },
//             new TypeBetail { Designation = "Mouton" },
//             // ... other TypeBetail instances ...
//         };

//     foreach (var type in types)
//     {
//         if (!context.TypesBetails.Any(t => t.Designation == type.Designation))
//         {
//             await context.TypesBetails.AddAsync(type);
//         }
//     }

//     // Save changes to ensure ArticleBetail and TypeBetail are persisted
//     await context.SaveChangesAsync();

//     // Add ArticleTypeBetail entities
//     var articleTypes = new[]
//     {
//             new ArticleTypeBetail
//             {
//                 ArticleBetailId = context.ArticlesBetails.Single(a => a.Designation == "Peau").Id,
//                 TypeBetailId = context.TypesBetails.Single(t => t.Designation == "Vache").Id,
//                 Qte = 1
//             },
//             // ... other ArticleTypeBetail instances ...
//         };

//     foreach (var articleType in articleTypes)
//     {
//         if (!context.ArticlesTypesBetails.Any(at => at.ArticleBetailId == articleType.ArticleBetailId && at.TypeBetailId == articleType.TypeBetailId))
//         {
//             await context.ArticlesTypesBetails.AddAsync(articleType);
//         }
//     }

//     // Final save to persist ArticleTypeBetail entities
//     await context.SaveChangesAsync();




//     //Chevillards

//     Chevillard chevillard1 = new Chevillard
//     {
//         Id = 1,
//         Nom = "Chevillard 1",
//         Plafond = 0,
//         Cin = "CIN 1",
//         CinImg = "CIN 1",
//         AcheteurIntestin = client1,
//         AcheteurPeau = client2,
//         AcheteurTete = client3,
//         AcheteurAutre = client1,
//         Num_carte = "Num carte 1",
//         Infos = "Infos 1",
//         Telephone = "Telephone 1",
//         Actif = true
//     };

//     Chevillard chevillard2 = new Chevillard
//     {
//         Id = 2,
//         Nom = "Chevillard 2",
//         Plafond = 0,
//         Cin = "CIN 2",
//         CinImg = "CIN 2",
//         AcheteurIntestin = client1,
//         AcheteurPeau = client2,
//         AcheteurTete = client3,
//         AcheteurAutre = client1,
//         Num_carte = "Num carte 2",
//         Infos = "Infos 2",
//         Telephone = "Telephone 2",
//         Actif = true
//     };


//     //Save chevillards

//     var chevillards = serviceScope.ServiceProvider.GetRequiredService<IUnitOfWork>().Chevillards;

//     await chevillards.AddAsync(chevillard1);
//     await chevillards.AddAsync(chevillard2);


//     //Receptions

//     Reception reception1 = new Reception
//     {
//         Id = 1,
//         Chevillard = chevillard1,
//         Tripier = 1,
//         Nombre = 1,
//         StabulationVaches = stabulation1,
//         StabulationMoutons = stabulation2,
//         StabulationBovins = stabulation3,
//         NbBovins = 1,
//         NbVaches = 1,
//         NbMoutons = 1,
//         AcheteurIntestin = client1,
//         AcheteurPeau = client2,
//         AcheteurTete = client3,
//         AcheteurAutre = client1
//     };

//     Reception reception2 = new Reception
//     {
//         Id = 2,
//         Chevillard = chevillard2,
//         Tripier = 1,
//         Nombre = 1,
//         StabulationVaches = stabulation1,
//         StabulationMoutons = stabulation2,
//         StabulationBovins = stabulation3,
//         NbBovins = 1,
//         NbVaches = 1,
//         NbMoutons = 1,
//         AcheteurIntestin = client1,
//         AcheteurPeau = client2,
//         AcheteurTete = client3,
//         AcheteurAutre = client1
//     };


//     //Save receptions

//     var receptions = serviceScope.ServiceProvider.GetRequiredService<IUnitOfWork>().Receptions;

//     await receptions.AddAsync(reception1);
//     await receptions.AddAsync(reception2);

//     // Carcasses

//     var depots = serviceScope.ServiceProvider.GetRequiredService<IUnitOfWork>().Depots;

//     Depot depot1 = new Depot
//     {
//         Id = 1,
//         Nom = "Depot 1",
//         Adresse = "Adresse 1"
//     };

//     Depot depot2 = new Depot
//     {
//         Id = 2,
//         Nom = "Depot 2",
//         Adresse = "Adresse 2"
//     };

//     Depot depot3 = new Depot
//     {
//         Id = 3,
//         Nom = "Depot 3",
//         Adresse = "Adresse 3"
//     };

//     await depots.AddAsync(depot1);
//     await depots.AddAsync(depot2);
//     await depots.AddAsync(depot3);



//     // Add your seeding logic here
//     context.SaveChanges();
// }


// ///SEED END 

app.Run();
