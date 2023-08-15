using FoodMarket.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Add AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);
//Add Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        RequireExpirationTime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration.GetSection("Jwt:Issuer").Value,
        ValidAudience = builder.Configuration.GetSection("Jwt:Audience").Value
    };

});
//Add Authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin",
         policy => policy.RequireRole("Admin"));
});
//Add MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
//Add LazyCache
builder.Services.AddLazyCache();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Demo Jwt",
        Version = "v1"
    });
     c.ExampleFilters();
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Insert Jwt with Beard intro field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
     {
     {new OpenApiSecurityScheme
          {
               Reference = new OpenApiReference
               {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
               }
          },
          Array.Empty<string>()
     }});
    //Api Documentation
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});
//Add DataBase Context
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
//Add Swagger Examples
builder.Services.AddSwaggerExamplesFromAssemblyOf<Program>();
//Add User Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 5;
}).AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();
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
