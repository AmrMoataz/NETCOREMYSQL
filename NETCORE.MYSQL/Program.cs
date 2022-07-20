using Microsoft.EntityFrameworkCore;
using NETCORE.MYSQL.Data.DBContext;
using NETCORE.MYSQL.Data.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("MySQL");
builder.Services.AddDbContext<MySQLDBContext>(options => options.UseMySql(connectionString, new MySqlServerVersion(new Version(10, 4, 20))));
builder.Services.AddScoped<IUnitOfWork>(sp =>
{
	var dbContext = sp.GetRequiredService<MySQLDBContext>();
	return new UnitOfWork(dbContext);
});
builder.Services.AddCors(options =>
{
	options.AddPolicy(name: "MyPolicy",
					builder =>
					{
						builder.AllowAnyOrigin()
						.AllowAnyHeader()
						.AllowAnyMethod();
					});
});
var app = builder.Build();

app.UseCors("MyPolicy");

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
