using CodeWearApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDataContext>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(); 

app.MapGet("/", () => "Hello World!");
app.MapControllers();

app.Run();
