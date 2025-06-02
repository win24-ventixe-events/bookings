using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using VentrixeBookings.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using VentrixeBookings.Data.Entities.UserBookingsRepository;
using VentrixeBookings.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<BookingServices>();
builder.Services.AddScoped<BookingRepository>();

var jwt = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwt["Key"]!);

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme    = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer           = true,
            ValidIssuer              = jwt["Issuer"],
            ValidateAudience         = true,
            ValidAudience            = jwt["Audience"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey         = new SymmetricSecurityKey(key),
            ValidateLifetime         = true,
            ClockSkew                = TimeSpan.Zero
        };
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact",
        policy => policy
            .AllowAnyOrigin()
            .WithHeaders("Authorization", "Content-Type", "Accept")
            .AllowAnyMethod());
});

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowReact");
//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
