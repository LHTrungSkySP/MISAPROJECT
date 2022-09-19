using MISA.WEB07.LHTRUNG.GD.BUS;
using MISA.WEB07.LHTRUNG.GD.BUS.GroupBUS;
using MISA.WEB07.LHTRUNG.GD.BUS.Manager.BaseManager;
using MISA.WEB07.LHTRUNG.GD.BUS.Manager.StorageRoomMNGBUS;
using MISA.WEB07.LHTRUNG.GD.BUS.Manager.SubjectMNGBUS;
using MISA.WEB07.LHTRUNG.GD.BUS.StorageRoomBUS;
using MISA.WEB07.LHTRUNG.GD.DAL;
using MISA.WEB07.LHTRUNG.GD.DAL.BaseDAL;
using MISA.WEB07.LHTRUNG.GD.DAL.GroupDAL;
using MISA.WEB07.LHTRUNG.GD.DAL.Manager.BaseManager;
using MISA.WEB07.LHTRUNG.GD.DAL.Manager.StorageRoomMNGDAL;
using MISA.WEB07.LHTRUNG.GD.DAL.Manager.SubjectMNGDAL;
using MISA.WEB07.LHTRUNG.GD.DAL.OfficerDAL;
using MISA.WEB07.LHTRUNG.GD.DAL.StorageRoomDAL;
using MISA.WEB07.LHTRUNG.GD.DAL.SubjectDAL;

var builder = WebApplication.CreateBuilder(args);

// connect with database
DatabaseContext.ContextString = builder.Configuration.GetConnectionString("MySqlConnection");

// Dependency injection
builder.Services.AddScoped(typeof(IBaseDAL<>), typeof(BaseDAL<>));
builder.Services.AddScoped(typeof(IBaseBUS<>), typeof(BaseBUS<>));

builder.Services.AddScoped(typeof(IBaseManagerDAL<>), typeof(BaseManagerDAL<>));
builder.Services.AddScoped(typeof(IBaseManagerBUS<>), typeof(BaseManagerBUS<>));

builder.Services.AddScoped<IOfficerDAL, OfficerDAL>();
builder.Services.AddScoped<IOfficerBUS, OfficerBUS>();

builder.Services.AddScoped<ISubjectDAL, SubjectDAL>();
builder.Services.AddScoped<ISubjectBUS, SubjectBUS>();

builder.Services.AddScoped<IStorageRoomDAL, StorageRoomDAL>();
builder.Services.AddScoped<IStorageRoomBUS, StorageRoomBUS>();

builder.Services.AddScoped<IGroupDAL, GroupDAL>();
builder.Services.AddScoped<IGroupBUS, GroupBUS>();

builder.Services.AddScoped<ISubjectManagerDAL, SubjectManagerDAL>();
builder.Services.AddScoped<ISubjectManagerBUS, SubjectManagerBUS>();

builder.Services.AddScoped<IStorageRoomManagerDAL, StorageRoomManagerDAL>();
builder.Services.AddScoped<IStorageRoomMNGBUS, StorageRoomMNGBUS>();

builder.Services.AddControllers();

// Validate entity sử dụng ModelState
builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
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

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
app.UseAuthorization();

app.UseAuthorization();

app.MapControllers();

app.Run();
