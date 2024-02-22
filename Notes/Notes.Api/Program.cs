using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Notes.Helpers;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var noteAppSettings = builder.Configuration.GetSection("NoteAppSettings");
var noteAppSettingsObject = noteAppSettings.Get<NoteAppSettings>();
var cs = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.InjectDbContext(cs);
builder.Services.RegisterRepositories();
builder.Services.RegisterServices();

var secretKey = Encoding.ASCII.GetBytes(noteAppSettingsObject.SecretKey);

// CONFIGURE JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(secretKey)
    };
});


// Adding CORS policy
builder.Services.AddCors(options => options.AddPolicy("myPolicy", policy =>
policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));


var app = builder.Build();

app.UseCors("myPolicy");

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
