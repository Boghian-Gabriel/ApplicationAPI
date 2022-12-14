using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using API.Repository;
using API.IRepository;
using API.Mapper;
using API.Context;
using API.Model;
using Microsoft.AspNetCore.Identity;
using API.IRepository.IGenreRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Connection to DataBase
builder.Services.AddDbContext<ContextDB>(option =>
      option.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

//add dependecy injection
builder.Services.AddScoped<ICreatableRepository, GenreRepository>();
builder.Services.AddScoped<IGettableRepository, GenreRepository>();
builder.Services.AddScoped<IUpdateableRepository, GenreRepository>();
builder.Services.AddScoped<IDeleteableRepository, GenreRepository>();


builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IActorRepository, ActorRepository>();
builder.Services.AddScoped<IActorAdressRepository, ActorAdressRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllersWithViews();
//AutoMapper
builder.Services.AddAutoMapper(typeof(AppMapper));

//Add Support XML Format
//builder.Services.AddControllers(setupAction =>
//{
//    setupAction.ReturnHttpNotAcceptable = true;
//}).AddXmlDataContractSerializerFormatters();

builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.PropertyNamingPolicy = null;
});

builder.Services.AddControllers()
           .AddJsonOptions(o => o.JsonSerializerOptions
           .ReferenceHandler = ReferenceHandler.IgnoreCycles);

// We can see that Swagger support is added automatically to
// our project:
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    {   
        Title = "API.Net Core 6", 
        Version = "v1" ,
        Description= "API example for learning "
    });
    c.EnableAnnotations();
    //add security definition
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"Jwt Authorization header using the Bearer scheme. 
                        Enter 'Bearer' [space] and then your token in the text input below
                        Example:  Bearer token1231asd ",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    //add secutiry requirment
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});


//add services authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    //Adding Jwt Bearer
    .AddJwtBearer(option =>
    {
        option.TokenValidationParameters = new TokenValidationParameters
        {
           ValidateIssuer = true,
           ValidateAudience = true,
           ValidateLifetime = true,
           ValidateIssuerSigningKey = true,
           ValidIssuer = builder.Configuration["Jwt:Issuer"],
           ValidAudience = builder.Configuration["Jwt:Audience"],
           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"]))
        };
    });


var app = builder.Build();

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
