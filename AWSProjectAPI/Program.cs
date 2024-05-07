using AWSProjectAPI.DataAccess.Authentication;
using AWSProjectAPI.DataAccess.BugFixes;
using AWSProjectAPI.DataAccess.Common;
using AWSProjectAPI.DataAccess.SystemEnhancements;
using AWSProjectAPI.Notification;
using AWSProjectAPI.Service.Authentication;
using AWSProjectAPI.Service.BugFixes;
using AWSProjectAPI.Service.Common;
using AWSProjectAPI.Service.SystemEnhancements;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Injecting service classes
builder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();
builder.Services.AddSingleton<IBugFixesService, BugFixesService>();
builder.Services.AddSingleton<ICommonService, CommonService>();
builder.Services.AddSingleton<ISystemEnhancementsService, SystemEnhancementsService>();

// Injecting dataaccess classes
builder.Services.AddSingleton<IAuthenticationDataAccess, AuthenticationDataAccess>();
builder.Services.AddSingleton<IBugFixesDataAccess, BugFixesDataAccess>();
builder.Services.AddSingleton<ICommonDataAccess, CommonDataAccess>();
builder.Services.AddSingleton<ISystemEnhancementsDataAccess, SystemEnhancementsDataAccess>();




builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.WithOrigins(
                        "https://iitcdemo.com", "http://localhost:4200")
                        .AllowCredentials()
                        .AllowAnyHeader()
                        .SetIsOriginAllowed(_ => true)
                        .AllowAnyMethod()
            );
});
builder.Services.AddSignalR();

// Token based related methods 
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        //ValidIssuer = "https://liveapi.iitcglobal.net",
        //ValidAudience = "https://liveapi.iitcglobal.net",
        //ValidIssuer = "http://localhost:7250",
        //ValidAudience = "http://localhost:7250",
        ValidIssuer = "https://iitcdemoapi.com/AWSAPI",
        ValidAudience = "https://iitcdemoapi.com/AWSAPI",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345superSecretKey@345"))
    };
});

// Adding the Json options
builder.Services.AddMvc().AddJsonOptions(o =>
{
    o.JsonSerializerOptions.PropertyNamingPolicy = null;
    o.JsonSerializerOptions.DictionaryKeyPolicy = null;
});
builder.Services.AddSession();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}





app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseRouting();
app.UseDefaultFiles();
app.UseStaticFiles();

app.MapHub<NotificationHub>("/notificationHub");

app.Run();
