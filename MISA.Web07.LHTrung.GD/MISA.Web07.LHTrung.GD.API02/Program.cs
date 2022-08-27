using MISA.Web07.LHTrung.GD.DL;


var builder = WebApplication.CreateBuilder(args);

// connect with database
DatabaseContext.ContextString = builder.Configuration.GetConnectionString("MySqlConnection");

// Add services to the container.
//builder.Services.AddScoped(typeof(IBaseDL<>), typeof(BaseDL<>));
//builder.Services.AddScoped(typeof(IBaseBL<>), typeof(BaseBL<>));
//builder.Services.AddScoped<IOfficerDL, OfficerDL>();
//builder.Services.AddScoped<IGroupDL, GroupDL>();
//builder.Services.AddScoped<IGroupBL, GroupBL>();
//builder.Services.AddScoped<IOfficerBL, OfficerBL>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddJsonOptions(options =>
options.JsonSerializerOptions.PropertyNamingPolicy = null);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
app.UseAuthorization();

app.MapControllers();

app.Run();
