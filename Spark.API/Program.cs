using Microsoft.EntityFrameworkCore;
using Spark.DataAccessLayer;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SparkDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConStr"), sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.MigrationsAssembly("Spark.DataAccessLayer");
        sqlOptions.EnableRetryOnFailure();
        //Branch icin deneme 
    });
});

   

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
