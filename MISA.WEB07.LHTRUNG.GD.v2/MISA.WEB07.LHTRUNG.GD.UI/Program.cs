using MISA.WEB07.LHTRUNG.GD;
using MISA.WEB07.LHTRUNG.GD.BUS;
using MISA.WEB07.LHTRUNG.GD.DAL;

var builder = WebApplication.CreateBuilder(args);

// connect with database
DatabaseContext.ContextString = builder.Configuration.GetConnectionString("MySqlConnection");

// Dependency injection
builder.Services.AddScoped(typeof(IBaseDAL<>), typeof(BaseDAL<>));
builder.Services.AddScoped(typeof(IBaseBUS<>), typeof(BaseBUS<>));
builder.Services.AddScoped<IOfficerDAL, OfficerDAL>();
builder.Services.AddScoped<IOfficerBUS, OfficerBUS>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseCors(builder => builder
//    .AllowAnyOrigin()
//    .AllowAnyMethod()
//    .AllowAnyHeader());
//app.UseAuthorization();

app.UseAuthorization();

app.MapControllers();

app.Run();
