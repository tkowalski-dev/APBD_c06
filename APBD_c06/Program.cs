var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// Dodać zależność bazy danych

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();


// dotnet ef migrations add AddedFirstTables
// dotnet ef migrations add AddedAssociations
// dotnet ef database update

// dotnet ef database update 0  // wycofuje migracje
// dotnet ef database update [lp/nazwa]  // wycofuje migracje do wskazanego miejsca
