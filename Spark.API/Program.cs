using Microsoft.EntityFrameworkCore;
using Spark.Core.IntRepository;
using Spark.Core.IntService;
using Spark.Core.IntUnitOfWork;
using Spark.DataAccessLayer;
using Spark.DataAccessLayer.Repository;
using Spark.DataAccessLayer.UnitOfWork;
using Spark.Services.Services;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers().AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
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
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ILikeService, LikeService>();

builder.Services.AddScoped<IChatService, ChatService>();

builder.Services.AddScoped<IGameService,GameService>();
builder.Services.AddScoped<IUserAnswerService,UserAnswerService>();


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
