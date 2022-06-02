using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Pre_aceleracion_Rodrigo_Roman.Context;
using Pre_aceleracion_Rodrigo_Roman.Interfaces;
using Pre_aceleracion_Rodrigo_Roman.Models;
using Pre_aceleracion_Rodrigo_Roman.Repositories;
using Pre_aceleracion_Rodrigo_Roman.Services;
using SendGrid.Extensions.DependencyInjection;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

//inyeccion de dependencias
builder.Services.AddEntityFrameworkSqlServer(); // se indica que se trabajara con EF
builder.Services.AddDbContext<DisneyContext>((services, options) =>
{
    options.UseApplicationServiceProvider(services);
    //para que no esté hardocodeado se le pasa como parametro una variable que contiene el string de conexion
    options.UseSqlServer(builder.Configuration.GetConnectionString("DisneyConnectionString"));
});

builder.Services.AddDbContext<UserContext>((services, options) =>
{
    options.UseApplicationServiceProvider(services);
    //para que no esté hardocodeado se le pasa como parametro una variable que contiene el string de conexion
    options.UseSqlServer(builder.Configuration.GetConnectionString("UsersConnectionString"));
});

builder.Services.AddSendGrid(x =>
{
    x.ApiKey = builder.Configuration["SendGridKey"];
});
//----------------------------------------INYECCIONES----------------------------------------
//-------------------------------------------------------------------------------------------
builder.Services.AddScoped<IGenresRepository, GenresRepository>();
builder.Services.AddScoped<ICharactersRepository, CharactersRepository>();
builder.Services.AddScoped<IMovieSeriesRepository, MovieSeriesRepository>();
//builder.Services.AddScoped<ICharacterMsRepository, CharacterMsRepository>();

builder.Services.AddScoped<IMailService, MailService>();
//builder.Services.AddSingleton(builder.Configuration);



builder.Services.AddIdentity<User, IdentityRole>().
    AddEntityFrameworkStores<UserContext>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false, //quien hace el token
        ValidateAudience = false, //para quien es el token
        //la palabra secreta para la firma del token
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtKey"]))
    };

});

var app = builder.Build();

var service = builder.Services.BuildServiceProvider();
var context = service.GetRequiredService<DisneyContext>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();