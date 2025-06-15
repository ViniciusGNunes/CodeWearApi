using CodeWearApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDataContext>();
builder.Services.AddControllers();


var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapControllers();


app.Run();
