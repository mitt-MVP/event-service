var builder = WebApplication.CreateBuilder(args);

// Lägg till CORS-policy för frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173") // frontend-porten
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Lägg till Controllers
builder.Services.AddControllers();

var app = builder.Build();

// Använd CORS-policy
app.UseCors("AllowFrontend");

app.UseHttpsRedirection();

app.MapControllers();

app.Run();