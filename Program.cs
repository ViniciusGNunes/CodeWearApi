using CodeWearApi.Data;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using CodeWearApi.Swagger;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDataContext>();
builder.Services.AddControllers();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddEndpointsApiExplorer(); 

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CodeWear API", Version = "v1" });
    c.OperationFilter<FileUploadOperation>(); // Adicione esta linha
});

var app = builder.Build();

app.UseStaticFiles(); // Habilita o wwwroot

// Enable CORS
app.UseCors("AllowAll");

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");
app.MapControllers();

app.Run();
