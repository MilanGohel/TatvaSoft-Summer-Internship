using Business_Logic_Layer;
using Business_Logic_Layer.JWTService;
using Data_Logic_Layer;
using Data_Logic_Layer.Entity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(db => db.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<BALLogin>();
builder.Services.AddScoped<DALLogin>();
builder.Services.AddScoped<BALAdminUser>();
builder.Services.AddScoped<DALAdminUser>();
builder.Services.AddScoped<BALAdminMissionTheme>();
builder.Services.AddScoped<DALAdminMissionTheme>();
builder.Services.AddScoped<DALMission>();
builder.Services.AddScoped<DALMissionApplication>();
builder.Services.AddScoped<DALMissionSkill>();
builder.Services.AddScoped<DALCity>();
builder.Services.AddScoped<DALCountry>();
builder.Services.AddScoped<BALCountry>();
builder.Services.AddScoped<BALCity>();
builder.Services.AddScoped<BALMissionApplication>();
builder.Services.AddScoped<BALMissionSkill>();
builder.Services.AddScoped<BALMission>();
builder.Services.AddScoped<BALCMS>();
builder.Services.AddScoped<DALCMS>();


builder.Services.AddScoped<JwtService>();

var myAllowSpecificOrigin = "_myAllowSpecificOrigin";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigin,
            policy =>
            {
                policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
            });
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    x=>
    {
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "localhost",
            ValidAudience = "localhost",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtConfig:Key"])),
            ClockSkew = TimeSpan.Zero
        };
    }
    );

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Adminpolicy", policy => policy.RequireRole("admin"));
});
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Jwt Token authorize",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(myAllowSpecificOrigin);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
