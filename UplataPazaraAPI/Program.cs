//dotnet ef dbcontext scaffold "Data Source=DESKTOP-GELLBOC\SQLEXPRESS;Initial Catalog=UplataPazaraDB;Integrated Security=true" Microsoft.EntityFrameworkCore.SqlServer -o MsSqlDb --context UplataDB 
using UplataPazaraAPI.MsSqlDb;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Prosireno zbog konekcije sa bazom
builder.Services.AddDbContext<UplataDB>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Prosireno zbog CORS-a
app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
